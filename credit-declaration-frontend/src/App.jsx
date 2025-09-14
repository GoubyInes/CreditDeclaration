import { useState } from 'react'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ActivityComponent from "./Components/ActivityComponent";
import MenuComponent from "./Components/MenuComponent";
import BankComponent from "./Components/BankComponent";
import EntityPublicComponent from "./Components/EntityPublicComponent";
import DurationComponent from "./Components/DurationComponent";
import DelayComponent from "./Components/DelayComponent";
import ChangeComponent from "./Components/ChangeComponent";
import StatusComponent from "./Components/StatusComponent";
import LevelComponent from "./Components/LevelComponent";
import FunctionComponent from "./Components/FunctionComponent";
import FormComponent from "./Components/FormComponent";
import WilayaComponent from "./Components/WilayaComponent";
import CommuneComponent from "./Components/CommuneComponent";
import PersonTypeComponent from "./Components/PersonTypeComponent";
import CollateralTypeComponent from "./Components/CollateralTypeComponent";
import CreditTypeComponent from "./Components/CreditTypeComponent";
import DocumentTypeComponent from "./Components/DocumentTypeComponent";
import PaysComponent from "./Components/PaysComponent";
import ProfessionComponent from "./Components/ProfessionComponent";
import SourceComponent from "./Components/SourceComponent";
import SituationComponent from "./Components/SituationComponent";
import PersonPhysicComponent from "./Components/PersonPhysicComponent";

import './App.css'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

function App() {
  const [count, setCount] = useState(0)

const queryClient = new QueryClient();


  return (
    //<UserProvider>
    <QueryClientProvider client={queryClient}>
      <BrowserRouter basename="/CreditDeclarationApp">
        <Routes>
          <Route path="/" element={<MenuComponent />}>
            <Route path="/Activity" element={<ActivityComponent />} />
            <Route path="/Bank" element={<BankComponent />} />
            <Route path="/Entity" element={<EntityPublicComponent />} />
            <Route path="/Duration" element={<DurationComponent />} />
            <Route path="/Delay" element={<DelayComponent />} />
            <Route path="/Change" element={<ChangeComponent />} />
            <Route path="/Form" element={<FormComponent />} />
            <Route path="/Function" element={<FunctionComponent />} />
            <Route path="/Level" element={<LevelComponent />} />
            <Route path="/PhysicPerson" element={<PersonPhysicComponent />} />
            <Route path="/Commune" element={<CommuneComponent />} />
            <Route path="/Wilaya" element={<WilayaComponent />} />
            <Route path="/PersonType" element={<PersonTypeComponent />} />
            <Route path="/CreditType" element={<CreditTypeComponent />} />
            <Route path="/CollateralType" element={<CollateralTypeComponent />} />
            <Route path="/DocumentType" element={<DocumentTypeComponent />} />
            <Route path="/Pays" element={<PaysComponent />} />
            <Route path="/Profession" element={<ProfessionComponent />} />
            <Route path="/Source" element={<SourceComponent />} />
            <Route path="/Status" element={<StatusComponent />} />
            <Route path="/Situation" element={<SituationComponent />} />
            <Route path="/PersonPhysic" element={<PersonPhysicComponent />} />
            
          </Route>
      </Routes>
      </BrowserRouter>
      </QueryClientProvider>
   // </UserProvider>
  );
}

export default App
