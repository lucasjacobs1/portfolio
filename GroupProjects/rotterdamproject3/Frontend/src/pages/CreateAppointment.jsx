import "../styles/CreateAppointment.css";
import Input from "../components/fields/Input";
import Select from "../components/fields/Select";
import React, { useState, useEffect} from "react"
import axios from 'axios'; 
import { useParams } from "react-router-dom";
import AppointmentServer from "../Server/AppointmentServer.js";

function CreateAppointment() {

    const [appointment, setAppointment] = useState({
        date: '',
        time: '',
        location: '',
    });

    const handleChange = (e) => {
        setAppointment({
            ...appointment,
            [e.target.name]: e.target.value
        });
        console.log(appointment);
    }

    const selectOptions = [
        { value: 'online', label: 'Online' },
        { value: 'location', label: 'At location' }
    ]

    const { usernameHashed,identifierHashed } = useParams();
    console.log(usernameHashed + " " + identifierHashed)
    const verifyAccess = async () => {
        AppointmentServer.verifyLinkAppointmentLink({usernameHashed,identifierHashed})
    }
  
    useEffect(() => {
        verifyAccess()
  },[]);

    return (
        <div id="block-drigro-content" className="block block-main page content block-system block-system-main-block">
            <div className="block-inner">
                <div role="article" typeof="schema:WebPage" className="paragraph-large">
                    <div>
                        <div className="mt-0 mb-6 paragraph paragraph--type--block paragraph--1021">
                            <div className="container">
                                <div className="row">
                                    <div className="col col-lg-8 body">
                                        <div className="block block-mijn driessen registratie block-custom-vacancy block-custom-vacancy-mijn-driessen-registration">
                                            <div className="block-inner">
                                                <div className="mijn-driessen-iframeregistration">
                                                    <form method="post" className="form-register form-register-page-1 form-view-embed">
                                                        <h2>Appointment Info</h2>
                                                        <fieldset>
                                                            <div className="row">
                                                                <div className="col-sm-6">
                                                                    <Input name="date" label="Date" onChange={handleChange} value={appointment.date} type="date" />
                                                                </div>
                                                            </div>
                                                            <div className="row">
                                                                <div className="col-sm-6">
                                                                    <Input name="time" label="Time" onChange={handleChange} value={appointment.time} type="time" />
                                                                </div>
                                                                <div className="col-sm-6">
                                                                    <Input name="duration" label="Duration" value="some duration" type="text" readonly={true} />
                                                                </div>
                                                            </div>
                                                            <div className="row">
                                                                <div className="col-sm-6">
                                                                    <Input label="Recruiter name" value="some name" type="text" readonly={true} />
                                                                </div>
                                                                <div className="col-sm-6">
                                                                    <Input label="Recruiter email" value="some email" type="text" readonly={true} />
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                        <h2>Location</h2>
                                                        <fieldset>
                                                            <div className="row">
                                                            <Select label="Location" onChange={handleChange} name="location" value={appointment.location} options={selectOptions}/>
                                                            </div>
                                                        </fieldset>
                                                        <div className="form-actions form-group mt-5">
                                                            <button type="submit" className="btn btn-success">Submit</button>
                                                        </div>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default CreateAppointment;