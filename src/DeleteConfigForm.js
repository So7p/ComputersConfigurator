import React, { Component, useEffect, useState, useCallback } from 'react';
import StyledButton from '@mui/material/Button';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './DeleteForm.css'

const getConfigurationsURL = `https://localhost:7193/api/Configurations/get-configurations`;
const deleteConfigurationURL = `https://localhost:7193/api/Configurations/delete-configuration/`;

function DeleteConfigForm(props) {
    const [configurationValues, setConfigurationValues] = useState([]);
    const [configurationOptions, setConfigurationOptions] = useState();

    function handleDeleteConfig() {
        const Config = {
            id: configurationOptions?.id,
        }

        axios
            .delete(deleteConfigurationURL + Config.id)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelDelete();
      }

    useEffect(()=>{
        fetch(getConfigurationsURL).then((data)=>data.json()).then((val)=>setConfigurationValues(val))
    },[])  

    function handleCancelDelete() {
        const deleteConfigForm = document.querySelector(".delete-config-form");
        deleteConfigForm.style.display = "none";
    }

    return(
        <div className='delete-form delete-config-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Идентификатор конфигурации
            </h5>
            <div className="data-components single-data-component">
                <FormControl className="id-select" component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="config-label">Номер</InputLabel>
                    <Select labelId="config-label" label="Номер" variant="filled" value={configurationOptions?.id ?? 1} onChange={(e) => setConfigurationOptions(configurationValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            configurationValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.id}</MenuItem>))
                        }
                    </Select>
                </FormControl>
            </div>
            <StyledButton className='confirm-delete-button' variant="outlined" type='submit' onClick={handleDeleteConfig}>Удалить</StyledButton>
            <StyledButton className='cancel-delete-button' variant="outlined" type='submit' onClick={handleCancelDelete}>Закрыть</StyledButton>
        </div>
    );
}

export default DeleteConfigForm;