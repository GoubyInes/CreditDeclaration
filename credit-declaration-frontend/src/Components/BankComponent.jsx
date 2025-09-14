import {useMemo, useState, useEffect } from 'react';
import {MaterialReactTable,useMaterialReactTable, MRT_EditActionButtons,} from 'material-react-table';
import BankService from '../Services/BankService';
import {Box, Button,colors,Dialog, DialogActions, DialogContent, DialogTitle, IconButton, Tooltip} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import {useMutation, useQuery, useQueryClient} from '@tanstack/react-query';

const BankComponent = () => {
  const [validationErrors, setValidationErrors] = useState({});
  const [data, setData] = useState([]);
  //call READ hook
  const {data: allBanks = [], sError: isLoadingDataError,isFetching: isFetchingData,isLoading: isLoadingData} = useQuery({
    queryKey: ['banks'],
    queryFn: BankService.getBanks,
  });
  const [pagination, setPagination] = useState({ pageIndex: 0,pageSize: 10,});
  const [totalRowCount, setTotalRowCount] = useState(0); 
  const [rowSelection, setRowSelection] = useState({}); 
 
  useEffect(() => {
    if (allBanks?.length) {
      setTotalRowCount(allBanks.length);
      const paginated = allBanks.slice(
        pagination.pageIndex * pagination.pageSize,
        (pagination.pageIndex + 1) * pagination.pageSize
      );
      setData(paginated);
    }
  }, [allBanks, pagination]);

  const columns = useMemo(
    () => [
      {
        accessorKey: 'code', //simple recommended way to define a column
        header: 'Code',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, //optional custom props
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, //optional custom cell render
        enableSorting: true, //sorting
        filterVariant: "range",  //filtering
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.code,
          helperText: validationErrors?.code,
        }
      },
      {
        accessorKey: 'descriptif', 
        header: 'Descriptif',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>,
        filterVariant: "range", 
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.descriptif,
          helperText: validationErrors?.descriptif,
          //remove any previous validation errors when user focuses on the input
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              descriptif: undefined,
            }),
          //optionally add validation checking for onBlur or onChange
        }, 
      },
      {
        accessorKey: 'domaine',
        header: 'Domaine',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.domaine,
          helperText: validationErrors?.domaine,
          //remove any previous validation errors when user focuses on the input
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              domaine: undefined,
            }),
          //optionally add validation checking for onBlur or onChange
        },
      },
    ],
    [validationErrors],
  );

   // MUTATIONS
  const { mutateAsync: create, isPending: isCreating } = useCreate();
  function useCreate() {
     const queryClient = useQueryClient();
     return useMutation({
        mutationFn :  async(bank) =>{ return await BankService.createBank(bank)},
        onMutate: async (bank) => {
          await queryClient.cancelQueries(['banks']);
          const previousBanks = queryClient.getQueryData(['banks']);
          queryClient.setQueryData(['banks'], (prev) => [
            ...(prev || []),
            {...bank},
          ]); 
          return { previousBanks };
        },
        onSuccess: () => queryClient.invalidateQueries(['banks']), //refrech data
    });
  }
  const { mutateAsync: update, isPending: isUpdating } = useUpdate()
  function useUpdate() {
    const queryClient = useQueryClient();
    return useMutation({
      mutationFn: async ({oldCode, data }) => {await BankService.updateBank(oldCode, data )},
      onMutate: (newInfo) => {
      queryClient.setQueryData(['banks'], (prev) =>
        prev?.map((prev) =>
          prev.code === newInfo.code ? newInfo : prev,
        ),
      );
    },
      onSuccess: () => queryClient.invalidateQueries(['banks']),
    });
  }
  const { mutateAsync: remove, isPending: isDeleting } = useDelete()
  function useDelete() {
    const queryClient = useQueryClient();
    return useMutation({
      mutationFn: BankService.deleteBank,
      onMutate: async (code) => {
        queryClient.setQueryData(['banks'], (prev) =>
          prev?.filter((p) => p.code !== code)
      )},
      onError: (err, code, context) => {if (context?.previousBanks) queryClient.setQueryData(['banks'], context.previousBanks); },//rollback
      onSettled: () => {queryClient.invalidateQueries(['banks']);}, // 🔄 Refetch depuis le serveur
      onSuccess: () => queryClient.invalidateQueries(['banks']),
    });
  }
  //CREATE action
  const handleCreate = async ({values, table }) => {
    const newValidationErrors = validate(values);
    if (Object.values(newValidationErrors).some((error) => error)) {
      setValidationErrors(newValidationErrors);
      return;
    }
    setValidationErrors({});
    await create(values);
    table.setCreatingRow(null); //exit creating mode
  }

  //UPDATE action
  const handleSave = async ({ values, table, row }) => {
    const newValidationErrors = validate(values);
    if (Object.values(newValidationErrors).some((error) => error)) {
      setValidationErrors(newValidationErrors);
      return;
    }
    setValidationErrors({});
    const oldCode = row.original.code;
    await update({oldCode, data: values });
    table.setEditingRow(null); //exit editing mode
  }

  //DELETE action
  const [openDeleteDialog, setOpenDeleteDialog] = useState(false);
  const [selectedRowToDelete, setSelectedRowToDelete] = useState(null);
  const openDeleteConfirmModal = async (row) => {
    setOpenDeleteDialog(true);
    setSelectedRowToDelete(row);
  };


  const table = useMaterialReactTable({
    columns,
    data,
    enableColumnOrdering: true, //enable some features
    //enableRowSelection: true,
    manualPagination: true, //Pagination
    rowCount:totalRowCount,
    onPaginationChange: setPagination,
    onRowSelectionChange: setRowSelection, //hoist internal state to your own state (optional)
    createDisplayMode: 'modal', //default ('row', and 'custom' are also available)
    editDisplayMode: 'modal', //default ('row', 'cell', 'table', and 'custom' are also available)
    enableEditing: true,
    getRowId: (row) => row.code,
    muiToolbarAlertBannerProps: isLoadingDataError
      ? {
          color: 'error',
          children: 'Error loading data',
        }
      : undefined,
    muiTableContainerProps: {
      sx: {
        minHeight: '500px',
      },
    },
    onCreatingRowCancel: () => setValidationErrors({}),
    onCreatingRowSave: handleCreate,
    onEditingRowCancel: () => setValidationErrors({}),
    onEditingRowSave: handleSave,
    //optionally customize modal content
    renderCreateRowDialogContent: ({ table, row, internalEditComponents }) => (
      <>
        <DialogTitle variant="h4">Créer nouvelle banque</DialogTitle>
        <DialogContent sx={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
          {internalEditComponents} {/* or render custom edit components here */}
        </DialogContent>
        <DialogActions>
          <MRT_EditActionButtons variant="text" table={table} row={row} />
        </DialogActions>
      </>
    ),
    //optionally customize modal content
    renderEditRowDialogContent: ({ table, row, internalEditComponents }) => (
      <>
        <DialogTitle variant="h4">Modifier banque</DialogTitle>
        <DialogContent sx={{ display: 'flex', flexDirection: 'column', gap: '1.5rem' }}>
          {internalEditComponents} {/* or render custom edit components here */}
        </DialogContent>
        <DialogActions>
          <MRT_EditActionButtons variant="text" table={table} row={row} />
        </DialogActions>
      </>
    ),
    renderRowActions: ({ row, table }) => (
      <Box sx={{ display: 'flex', gap: '1rem' }}>
        <Tooltip title="Edit">
          <IconButton onClick={() => table.setEditingRow(row)}>
            <EditIcon />
          </IconButton>
        </Tooltip>
        <Tooltip title="Delete">
          <IconButton onClick={() => openDeleteConfirmModal(row)}>
            <DeleteIcon />
          </IconButton>
        </Tooltip>
      </Box>
    ),
    renderTopToolbarCustomActions: ({ table }) => (
      <Button variant="contained" onClick={() => {table.setCreatingRow(true)}} style={{backgroundColor:'#ffcc00'}}>
        Créer banque
      </Button>
    ),
    state: {//manage your own state, pass it back to the table (optional)
      pagination,
      rowSelection,
      isLoading: isLoadingData,
      isSaving: isCreating || isUpdating || isDeleting,
      showAlertBanner: isLoadingDataError,
      showProgressBars: isFetchingData,
    },
  });

const validateRequired = (value) => !!value.length;
function validate(bank) {
  return {
    code: !validateRequired(bank.code)
      ? 'Code est requis'
      : '',
    descriptif: !validateRequired(bank.descriptif) ? 'Descriptif est requis' : '',
    domaine: !validateRequired(bank.domaine) ? 'Domaine est requis' : '',
  };
}

  return (
    <div>
      <h2>Liste des Banques</h2>
      <MaterialReactTable table={table} />

      <Dialog open={openDeleteDialog} onClose={() => setOpenDeleteDialog(false)}>
        <DialogTitle>Confirmer la suppression</DialogTitle>
        <DialogContent>
          Voulez-vous vraiment supprimer la banque <strong>{selectedRowToDelete?.original?.descriptif}</strong> ?
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDeleteDialog(false)}>Annuler</Button>
          <Button color="error" onClick={async () => {await remove(selectedRowToDelete.original.code); setOpenDeleteDialog(false)}}> Valider </Button>
        </DialogActions>
      </Dialog>
    </div>
    
  );
}

export default BankComponent;