import {useMemo, useState, useEffect } from 'react';
import {MaterialReactTable,useMaterialReactTable, MRT_EditActionButtons,} from 'material-react-table';
import PersonPhysicService from '../Services/PersonPhysicService';
import PaysService from '../Services/PaysService';
import CommuneService from '../Services/CommuneService';
import WilayaService from '../Services/WilayaService';
import StatusService from '../Services/StatusService';
import ProfessionService from '../Services/ProfessionService';
import DocumentTypeService from '../Services/DocumentTypeService';
import {Box, Button,colors,Dialog, DialogActions, DialogContent, DialogTitle, IconButton, Tooltip, MenuItem} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import {useMutation, useQuery, useQueryClient} from '@tanstack/react-query';

const PersonPhysicComponent = () => {
  const [validationErrors, setValidationErrors] = useState({});
  const [data, setData] = useState([]);
  //call READ hook
  const {data: allPersonPhysics = [], sError: isLoadingDataError,isFetching: isFetchingData,isLoading: isLoadingData} = useQuery({
    queryKey: ['PersonPhysics'],
    queryFn: PersonPhysicService.getPersonPhysics,
  });
  const [pagination, setPagination] = useState({pageIndex: 0,pageSize: 10,});
  const [totalRowCount, setTotalRowCount] = useState(0); 
  const [rowSelection, setRowSelection] = useState({}); 
  const [paysOptions, setPaysOptions]=useState({}); 
  const [wilayaOptions, setWilayaOptions]=useState({});
  const [communeOptions, setCommuneOptions]=useState({});
  const [etatOptions, setEtatOptions]=useState({});
  const [typeOptions, setTypeOptions]=useState({});
  const [professionOptions, setProfessionOptions]=useState({});

   const fetchCountries = async () => {
        try {const data= await PaysService.getCountries()
          setPaysOptions(data);
        }
        catch(error){}
  }
  const fetchCommunes = async () => {
        try {const data= await CommuneService.getCommunes()
          setCommuneOptions(data);
        }
        catch(error){}
  }
  const fetchStatus = async () => {
        try {const data= await StatusService.getStatus()
          setEtatOptions(data);
        }
        catch(error){}
  }
  const fetchWilayas = async () => {
        try {const data= await WilayaService.getWilayas(); 
          setWilayaOptions(data);
        }
        catch(error){}
  }
  const fetchTypes = async () => {
        try {const data= await DocumentTypeService.getDocTypes()
          setTypeOptions(data);
        }
        catch(error){}
  }
   const fetchProfessions = async () => {
        try {const data= await ProfessionService.getProfessions()
          setProfessionOptions(data);
        }
        catch(error){}
  }
  useEffect(() => {
    fetchCommunes(); fetchWilayas(); fetchCountries(); fetchStatus(); fetchTypes(); fetchProfessions ();
    if (allPersonPhysics?.length) {
      setTotalRowCount(allPersonPhysics.length);
      const paginated = allPersonPhysics.slice(
        pagination.pageIndex * pagination.pageSize,
        (pagination.pageIndex + 1) * pagination.pageSize
      );
      setData(paginated);
    }
  }, [allPersonPhysics, pagination]);

  const columns = useMemo(
    () => [
      {
        accessorKey: 'codeAgence', //simple recommended way to define a column
        header: 'Code Agence',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, //optional custom props
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, //optional custom cell render
        enableSorting: true, //sorting
        filterVariant: "range",  //filtering
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.codeAgence,
          helperText: validationErrors?.codeAgence,
        }
      },
      {
        accessorKey: 'clientRadical', //simple recommended way to define a column
        header: 'Client Radical',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, //optional custom props
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, //optional custom cell render
        enableSorting: true, //sorting
        filterVariant: "range",  //filtering
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.clientRadical,
          helperText: validationErrors?.clientRadical,
        }
      },
      {
        accessorKey: 'nom', 
        header: 'Nom',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>,
        filterVariant: "range", 
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.nom,
          helperText: validationErrors?.nom,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              nom: undefined,
            }),
        }, 
      },
      {
        accessorKey: 'prenom',
        header: 'Prenom',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.prenom,
          helperText: validationErrors?.prenom,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              prenom: undefined,
            }),
        },
      },
      {
        accessorKey: 'dateNaissance',
        header: 'DateNaissance',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.dateNaissance,
          helperText: validationErrors?.dateNaissance,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              dateNaissance: undefined,
            }),
        },
      },
      {
        accessorKey: 'presume',
        header: 'Presume',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.presume,
          helperText: validationErrors?.presume,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              presume: undefined,
            }),
        },
      },
      {
        accessorKey: 'numActeNaissance',
        header: 'Num Acte Naissance',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.presume,
          helperText: validationErrors?.presume,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              presume: undefined,
            }),
        },
      },
      {
        accessorKey: 'acteNaissance',
        header: 'Acte Naissance',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.acteNaissance,
          helperText: validationErrors?.acteNaissance,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              acteNaissance: undefined,
            }),
        },
      },
       {
        accessorKey: 'sexe',
        header: 'Sexe',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.sexe,
          helperText: validationErrors?.sexe,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              sexe: undefined,
            }),
        },
      },
      {
        accessorKey: 'nationalite',
        header: 'Nationalite',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.nationalite,
          helperText: validationErrors?.nationalite,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              nationalite: undefined,
            }),
        },
      },
      {
        accessorKey: 'paysNaissance',
        id: 'paysNaissance',
        header: 'Pays Naissance',
        accessorFn: (row) => row.paysNaissanceData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.paysNaissanceData?.descriptif|| row.original.paysNaissance}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"paysNaissance",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,paysNaissance: undefined,
            })),
          error: !!validationErrors?.paysNaissance,
          helperText: validationErrors?.paysNaissance,
          children: Array.isArray(paysOptions)? paysOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'wilayaNaissance',
        id: 'wilayaNaissance',
        header: 'Wilaya Naissance',
        accessorFn: (row) => row.wilayaNaissanceData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.wilayaNaissanceData?.descriptif|| row.original.wilayaNaissance}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"wilayaNaissance",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,wilayaNaissance: undefined,
            })),
          error: !!validationErrors?.wilayaNaissance,
          helperText: validationErrors?.wilayaNaissance,
          children: Array.isArray(wilayaOptions)? wilayaOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'communeNaissance',
        id: 'communeNaissance',
        header: 'Commune Naissance',
        accessorFn: (row) => row.communeNaissanceData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.communeNaissanceData?.descriptif || row.original.communeNaissance}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"communeNaissance",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,communeNaissance: undefined,
            })),
          error: !!validationErrors?.communeNaissance,
          helperText: validationErrors?.communeNaissance,
          children: Array.isArray(communeOptions)? communeOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'prenomPere',
        header: 'Prenom Pere',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.prenomPere,
          helperText: validationErrors?.prenomPere,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              prenomPere: undefined,
            }),
        },
      },
      {
        accessorKey: 'prenomMere',
        header: 'Prenom Mere',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.prenomMere,
          helperText: validationErrors?.prenomMere,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              prenomMere: undefined,
            }),
        },
      },
      {
        accessorKey: 'nomMere',
        header: 'Nom mere',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.nomMere,
          helperText: validationErrors?.nomMere,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              nomMere: undefined,
            }),
        },
      },
      {
        accessorKey: 'nomConjoint',
        header: 'Nom conjoint',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.nomConjoint,
          helperText: validationErrors?.nomConjoint,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              nomConjoint: undefined,
            }),
        },
      },
      {
        accessorKey: 'etatCivil',
        id: 'etatCivil',
        header: 'Etat Civil',
        accessorFn: (row) => row.etatCivilData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.etatCivilData?.descriptif|| row.original.etatCivil}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"etatCivil",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,etatCivil: undefined,
            })),
          error: !!validationErrors?.etatCivil,
          helperText: validationErrors?.etatCivil,
          children: Array.isArray(etatOptions)? etatOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
       {
        accessorKey: 'profession',
        id: 'profession',
        header: 'Profession',
        accessorFn: (row) => row.professionData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.professionData?.descriptif|| row.original.profession}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"profession",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,profession: undefined,
            })),
          error: !!validationErrors?.profession,
          helperText: validationErrors?.profession,
          children: Array.isArray(professionOptions)? professionOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'revenu',
        header: 'Revenu',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.revenu,
          helperText: validationErrors?.revenu,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              revenu: undefined,
            }),
        },
      },
      {
        accessorKey: 'adresse',
        header: 'Adresse',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.adresse,
          helperText: validationErrors?.adresse,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              adresse: undefined,
            }),
        },
      },
      {
        accessorKey: 'adresseWilaya',
        id: 'adresseWilaya',
        header: 'Adresse wilaya',
        accessorFn: (row) => row.adresseWilayaData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.adresseWilayaData?.descriptif|| row.original.adresseWilaya}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"adresseWilaya",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,adresseWilaya: undefined,
            })),
          error: !!validationErrors?.adresseWilaya,
          helperText: validationErrors?.adresseWilaya,
          children: Array.isArray(wilayaOptions)? wilayaOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'adresseCommune',
        id: 'adresseCommune',
        header: 'Adresse Commune',
        accessorFn: (row) => row.adresseCommuneData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.adresseCommuneData?.descriptif|| row.original.adresseCommune}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"adresseCommune",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,adresseCommune: undefined,
            })),
          error: !!validationErrors?.adresseCommune,
          helperText: validationErrors?.adresseCommune,
          children: Array.isArray(communeOptions)? communeOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'typeDoc',
        id: 'typeDoc',
        header: 'type Doc',
        accessorFn: (row) => row.typeDocData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.typeDocData?.descriptif|| row.original.typeDoc}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"typeDoc",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,typeDoc: undefined,
            })),
          error: !!validationErrors?.typeDoc,
          helperText: validationErrors?.typeDoc,
          children: Array.isArray(typeOptions)? typeOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'numDoc',
        header: 'Num Doc',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.numDoc,
          helperText: validationErrors?.numDoc,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              numDoc: undefined,
            }),
        },
      },
      {
        accessorKey: 'paysEmission',
        id: 'paysEmission',
        header: 'Pays emission',
        accessorFn: (row) => row.paysEmissionData?.descriptif ?? "",
        Cell: ({ row }) => (<span>{row.original.paysEmissionData?.descriptif|| row.original.paysEmission}</span>),
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        muiEditTextFieldProps: ({ cell, table }) => ({
          select: true,
          required: true,
          value: cell.getValue() || "", 
          onChange: (event) => {
            table.options.meta?.updateData?.( cell.row.index,"paysEmission",event.target.value);
          },
          onFocus: () =>
            setValidationErrors((prev) => ({
              ...prev,paysEmission: undefined,
            })),
          error: !!validationErrors?.paysEmission,
          helperText: validationErrors?.paysEmission,
          children: Array.isArray(paysOptions)? paysOptions.map((p) => (
            <MenuItem key={p.code} value={p.code}>
              {p.descriptif}
            </MenuItem>
          )): [],
        }),
      },
      {
        accessorKey: 'entiteEmettrice',
        header: 'Entite emettrice',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.entiteEmettrice,
          helperText: validationErrors?.entiteEmettrice,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              entiteEmettrice: undefined,
            }),
        },
      },{
        accessorKey: 'dateExpiration',
        header: 'Date expiration',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.dateExpiration,
          helperText: validationErrors?.dateExpiration,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              dateExpiration: undefined,
            }),
        },
      },{
        accessorKey: 'nif',
        header: 'Nif',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.nif,
          helperText: validationErrors?.nif,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              nif: undefined,
            }),
        },
      },{
        accessorKey: 'cleIntermediaire',
        header: 'Cle Intermediaire',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.cleIntermediaire,
          helperText: validationErrors?.cleIntermediaire,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              cleIntermediaire: undefined,
            }),
        },
      },{
        accessorKey: 'cleOnomastique',
        header: 'Cle Onomastique',
        muiTableHeadCellProps: { sx: { color: '#ffcc00' } }, 
        Cell: ({ cell }) => <span>{cell.getValue()}</span>, 
        filterVariant: "range" ,
        muiEditTextFieldProps: {
          required: true,
          error: !!validationErrors?.cleOnomastique,
          helperText: validationErrors?.cleOnomastique,
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              cleOnomastique: undefined,
            }),
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
        mutationFn :  async(PersonPhysic) =>{ return await PersonPhysicService.createPersonPhysic(PersonPhysic)},
        onMutate: async (PersonPhysic) => {
          await queryClient.cancelQueries(['PersonPhysics']);
          const previousPersonPhysics = queryClient.getQueryData(['PersonPhysics']);
          queryClient.setQueryData(['PersonPhysics'], (prev) => [
            ...(prev || []),
            {...PersonPhysic},
          ]); 
          return { previousPersonPhysics };
        },
        onSuccess: () => queryClient.invalidateQueries(['PersonPhysics']), //refrech data
    });
  }
  const { mutateAsync: update, isPending: isUpdating } = useUpdate()
  function useUpdate() {
    const queryClient = useQueryClient();
    return useMutation({
      mutationFn: async ({oldId, data }) => {await PersonPhysicService.updatePersonPhysic(oldId, data )},
      onMutate: (newInfo) => {
      queryClient.setQueryData(['PersonPhysics'], (prev) =>
        prev?.map((prev) =>
          prev.id === newInfo.id ? newInfo : prev,
        ),
      );
    },
      onSuccess: () => queryClient.invalidateQueries(['PersonPhysics']),
    });
  }
  const { mutateAsync: remove, isPending: isDeleting } = useDelete()
  function useDelete() {
    const queryClient = useQueryClient();
    return useMutation({
      mutationFn: PersonPhysicService.deletePersonPhysic,
      onMutate: async (id) => {
        queryClient.setQueryData(['PersonPhysics'], (prev) =>
          prev?.filter((p) => p.id !== id)
      )},
      onError: (err, id, context) => {if (context?.previousPersonPhysics) queryClient.setQueryData(['PersonPhysics'], context.previousPersonPhysics); },//rollback
      onSettled: () => {queryClient.invalidateQueries(['PersonPhysics']);}, // 🔄 Refetch depuis le serveur
      onSuccess: () => queryClient.invalidateQueries(['PersonPhysics']),
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
    console.log(values)
    setValidationErrors({});
    const oldId = row.original.id;
    await update({oldId, data: values });
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
    getRowId: (row) => row.id,
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
        <DialogTitle variant="h4">Créer nouvelle personne physique</DialogTitle>
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
        <DialogTitle variant="h4">Modifier personne physique</DialogTitle>
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
        Créer perseonne physique
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
function validate(PersonPhysic) {
  return {
    code: !validateRequired(PersonPhysic.codeAgence)? 'Code est requis' : '',
    descriptif: !validateRequired(PersonPhysic.nom) ? 'Nom est requis' : '',
    domaine: !validateRequired(PersonPhysic.prenom) ? 'Prenom est requis' : '',
  };
}

  return (
    <div>
      <h2>Liste des Personnes Physiques</h2>
      <MaterialReactTable table={table} />

      <Dialog open={openDeleteDialog} onClose={() => setOpenDeleteDialog(false)}>
        <DialogTitle>Confirmer la suppression</DialogTitle>
        <DialogContent>
          Voulez-vous vraiment supprimer la personne physique <strong>{selectedRowToDelete?.original?.descriptif}</strong> ?
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDeleteDialog(false)}>Annuler</Button>
          <Button color="error" onClick={async () => {await remove(selectedRowToDelete.original.id); setOpenDeleteDialog(false)}}> Valider </Button>
        </DialogActions>
      </Dialog>
    </div>
    
  );
}

export default PersonPhysicComponent;