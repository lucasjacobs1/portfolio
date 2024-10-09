
// import './App.css';
import "./styles/style.css";
import { Route, Routes, BrowserRouter as Router } from "react-router-dom";
import Navbar from "./components/navbar/Navbar";
import CreateAppointment from "./pages/CreateAppointment";
import VacancyOverviewPage from './pages/VacancyOverviewPage';
import CandidateOverviewPage from './pages/CandidateOverviewPage.';
import AppointmentPage from './pages/AppointmentPage';
import Appointment from "./appointment/OverviewAppointmentPage"
<link href="//db.onlinewebfonts.com/c/dff56d27e2d0710a764d0f2d4fe2bc03?family=Roihu" rel="stylesheet" type="text/css" />;
<link href="//db.onlinewebfonts.com/c/840e46f8bc6d4e0072efe9a68fe8ad3c?family=Ratio+ Thin" rel="stylesheet" type="text/css" />;

function App() {
  return (
    <div className="dialog-off-canvas-main-canvas" data-off-canvas-main-canvas>
      <div className="layout">
        <Router>
          <Navbar/>
          <Routes>
            <Route path="appointment">
              <Route path="create/:username/:identifier" element={<CreateAppointment />}></Route>
            </Route>
            <Route path="/" element={<VacancyOverviewPage />} />
            <Route path="/Candidates/:vacancyId" element={<CandidateOverviewPage />} />
            <Route path="/singleappointment/:appointmentId" element={<AppointmentPage />} />
            <Route path="/appointments" element={<Appointment />} />

          </Routes>
        </Router>
      </div>
    </div>
  );
}

export default App;