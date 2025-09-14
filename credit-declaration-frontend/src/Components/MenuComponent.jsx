import React,  { useEffect, useState }  from 'react';
import { SolutionOutlined, BarsOutlined, AccountBookOutlined, CloseSquareOutlined, BankOutlined, ContactsOutlined} from '@ant-design/icons';
import { Breadcrumb, Layout, Menu, theme, Button } from 'antd';
import { Link, Outlet  } from 'react-router-dom';
import './FormComponent.css';
import logo from '../bnhLogo.png';  
import { useNavigate } from "react-router-dom";
import ActivityComponent from './ActivityComponent';

    const { Header, Content, Footer, Sider } = Layout;
    const MenuComponent = () => {
      
    const [user, setUser] = useState(null);
    const [isAdmin, setIsAdmin] = useState(false);
  
   /* useEffect(() => {
      const currentUser = AuthService.getCurrentUser();
      setUser(currentUser);
      setIsAdmin(currentUser?.username == 'admin');
    }, []); */

    const items = [
      {key: '1', icon: <SolutionOutlined />, label: <Link to="/Activity">Liste activités</Link>},
      {key: '2', icon: <SolutionOutlined />, label: <Link to="/Bank">Liste banques</Link>},
      {key: '3', icon: <SolutionOutlined />, label: <Link to="/Entity">Liste des entité</Link>},
      {key: '4', icon: <SolutionOutlined />, label: <Link to="/Duration">Liste des durées crédit</Link>},
      {key: '5', icon: <SolutionOutlined />, label: <Link to="/Delay">Liste des classes retard</Link>},
      {key: '6', icon: <SolutionOutlined />, label: <Link to="/Status">Liste des état civil</Link>},
      {key: '7', icon: <SolutionOutlined />, label: <Link to="/Change">Liste des monnaies</Link>},
      {key: '8', icon: <SolutionOutlined />, label: <Link to="/Level">Liste des niveau résponsabilité</Link>},
      {key: '9', icon: <SolutionOutlined />, label: <Link to="/Form">Liste des formes juridique</Link>},
      {key: '10', icon: <SolutionOutlined />, label: <Link to="/Function">Liste des fonctions dirigeant</Link>},
      {key: '11', icon: <SolutionOutlined />, label: <Link to="/PersonPhysic">Liste des peronnes physiques</Link>},
      {key: '12', icon: <SolutionOutlined />, label: <Link to="/Wilaya">Liste des wilayas</Link>},
      {key: '13', icon: <SolutionOutlined />, label: <Link to="/Commune">Liste des communes</Link>},
      {key: '14', icon: <SolutionOutlined />, label: <Link to="/PersonType">Liste des types personnes</Link>},
      {key: '15', icon: <SolutionOutlined />, label: <Link to="/CreditType">Liste des types credit</Link>},
      {key: '16', icon: <SolutionOutlined />, label: <Link to="/CollateralType">Liste des types garantie</Link>},
      {key: '17', icon: <SolutionOutlined />, label: <Link to="/DocumentType">Liste des types document</Link>},
      {key: '18', icon: <SolutionOutlined />, label: <Link to="/Profession">Liste des profession</Link>},
      {key: '19', icon: <SolutionOutlined />, label: <Link to="/Pays">Liste des pays</Link>},
      {key: '20', icon: <SolutionOutlined />, label: <Link to="/Situation">Liste des situations</Link>},
      {key: '21', icon: <SolutionOutlined />, label: <Link to="/Source">Liste des sources</Link>},
       ]
   
    const navigate = useNavigate();
    const handleLogout = async (e) => {
      e.preventDefault();
      // AuthService.logout();
      navigate("/Login");  
    };
    

    const [collapsed, setCollapsed] = useState(true);
    const {token: { colorBgContainer, borderRadiusLG },} = theme.useToken();

    return (
      <Layout style={{minHeight: '100vh'}} >
         <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)} style={{ backgroundColor: '#fdfcfc8f' }}>
          <img src={logo} style={{marginLeft:'10%', width: '80%', marginTop:'5%' }} />
          <Menu  defaultSelectedKeys={['1']} mode="inline" items={items} style={{backgroundColor: '#fdfcfc8f', color:'black', paddingTop:'20px' }}/>
        </Sider>

        <Layout id="layout">
          <Header style={{padding: 0, background: 'rgb(182, 178, 178)', height:'5%'}}>
            <div style={{textAlign:'right'}} >
              <span style={{color:'white', fontSize:'1.3em'}}> {user && (user.lastname)} </span>
              <CloseSquareOutlined onClick={handleLogout} style={{fontSize: '25px', color:'white', marginRight:'20px'}}/> 
            </div>
          </Header>
          <Content style={{margin: '0 16px', height:'92%'}}>
            <Breadcrumb style={{margin: '16px 0'}}></Breadcrumb>
            <div style={{padding: 24, background: colorBgContainer, borderRadius: borderRadiusLG, height:'95%'}}>
              <Outlet />   
            </div>
          </Content>
          
          <Footer style={{ textAlign: 'center', padding:'7px'}}>
            <span style={{opacity:'0.5'}}>Version 1.0.0</span>
          </Footer>
        </Layout>
      </Layout>
    );
  };
export default MenuComponent;

/*
              <Breadcrumb.Item>Bill</Breadcrumb.Item> */