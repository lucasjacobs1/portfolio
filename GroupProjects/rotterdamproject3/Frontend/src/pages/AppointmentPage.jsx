import React, { useEffect, useState } from "react"
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import style from "../components/Style1.css"
import http from "../Server/http-common"


function AppointmentPage() {

    const [appointment, setAppointment] = useState();
    const [currentAppointment, setCurrentAppointment] = useState();
    const { appointmentId } = useParams()

    const Navigate = useNavigate()

    const getAppointmentById = async (id) => {
        await http.get(`appointments/${id}`)
            .then((response) => {
                console.log(response)
                setAppointment(response.data)
            })
            .catch((error) => {
                console.error(error);
            });
    };

    function removeAppointmentById(event) {
        event.preventDefault();
        http.delete(`appointments/id/${appointment.id}`);
        Navigate("/appointments")
    };

    function updateAppointment(newEmail, event) {
        event.preventDefault();
        let data = {
            id: appointment.id,
            RecruiterEmail: newEmail.toString()
        }
        http.put("appointments", data)
        window.location.reload()
    }

    useEffect(() => {
        getAppointmentById(appointmentId);
    }, []);

    function openForm() {
        document.getElementById("myForm").classList.add("form-popup-opened")
    }

    function closeForm() {
        document.getElementById("myForm").classList.remove("form-popup-opened")
    }

    if (appointment == undefined) {
        return (<p>loading...</p>)
    }
    else
        return (
            <section className={style.Style1}>
                <div className="containerTom">
                    <div className="containerTom">
                        <h1>Appointment information</h1>
                        <table className="tableTom">
                            <tbody>
                                <tr>
                                    <td className="data1">Subject</td>
                                    <td className="data2">{appointment.subject.toString()}</td>
                                </tr>
                                <tr>
                                    <td className="data1">Recruiter's name</td>
                                    <td className="data2">{appointment.recruiterFirstName.toString()} {appointment.recruiterLastName.toString()}</td>
                                </tr>
                                <tr>
                                    <td className="data1">Candidate's name</td>
                                    <td className="data2">{appointment.candidateFirstName.toString()} {appointment.candidateLastName.toString()}</td>
                                </tr>
                                <tr>
                                    <td className="data1">Starts at</td>
                                    <td className="data2">{appointment.startDate.toString()}</td>
                                </tr>
                                <tr>
                                    <td className="data1">Ends at</td>
                                    <td className="data2">{appointment.endDate.toString()}</td>
                                </tr>
                                <tr>
                                    <td className="data1">Meeting will be held at</td>
                                    <td className="data2">{appointment.location.toString()}</td>
                                </tr>
                            </tbody>
                        </table>


                        <div className="flex-containerTom">
                            <button className="btnTom" onClick={e => removeAppointmentById(appointment.id, e)}>Cancel the appointment</button>
                            <button className="btnTom" onClick={openForm}> Change the recruiter </button>
                        </div>
                    </div>
                    <div className="form-popup" id="myForm">
                        <form action="/action_page.php" className="form-container">

                            <input id="email" type="text" placeholder="New recruiter email" required></input>

                            <button type="submit" className="btn" onClick={e => updateAppointment(document.getElementById("email").value, e)}>Assign</button>
                            <button type="button" className="btn cancel" onClick={closeForm}>Close</button>
                        </form>
                    </div>

                </div>
            </section>
        );
}

export default AppointmentPage

