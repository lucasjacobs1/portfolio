import http from "./ServerBase";


http.create.baseURL += "/appointments"

const verifyLinkAppointmentLink = (linkValidation) => {
    return http.get(`/verifyLink?usernameHashed=${linkValidation.usernameHashed}}&identifierHashed=${linkValidation.identifierHashed}`);
};

const getAllAppointments = () =>{
    return http.get("/appointments");
}

const getAppointmentsFilterAscending = () =>{
    return http.get("/FilterDateAscending")
}

const getAppointmentsFilterDecending = () =>{
    return http.get("/FilterDateDescending")
}

const getAppointmentsBySubjectName = subject =>{
    return http.get(`/SearchBySubject/${subject}`)
}

const AppointmentService ={
    verifyLinkAppointmentLink,

    getAllAppointments,
    getAppointmentsFilterAscending,
    getAppointmentsFilterDecending,
    getAppointmentsBySubjectName
};

export default AppointmentService;