import React, { Component, useEffect, useState, useCallback } from 'react';
import StyledButton from '@mui/material/Button';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './CreateForm.css'

const getModelsURL = `https://localhost:7193/api/Models/get-models`;

const deleteModelURL = `https://localhost:7193/api/Models/delete-model/`;

function DeleteModelForm(props) {
    const [modelValues, setModelValues] = useState([]);
    const [modelOptions, setModelOptions] = useState();

    function handleDeleteModel() {
        const Model = {
            id: modelOptions?.id
        }

        axios
            .delete(deleteModelURL + Model.id)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelDelete()
      }

    useEffect(()=>{
        fetch(getModelsURL).then((data)=>data.json()).then((val)=>setModelValues(val))
    },[])

    function handleCancelDelete() {
        const deleteModelForm = document.querySelector(".delete-model-form");
        deleteModelForm.style.display = "none";
    }

    return(
        <div className='delete-form delete-model-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Идентификатор модели
            </h5>
            <div className="data-components single-data-component">
                <FormControl className="id-select" component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="model-label">Номер</InputLabel>
                    <Select labelId="model-label" label="Номер" variant="filled" value={modelOptions?.id ?? 1} onChange={(e) => setModelOptions(modelValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            modelValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.id}</MenuItem>))
                        }
                    </Select>
                </FormControl>   
            </div>
            <StyledButton className='confirm-update-button' variant="outlined" type='submit' onClick={handleDeleteModel}>Удалить</StyledButton>
            <StyledButton className='cancel-update-button' variant="outlined" type='submit' onClick={handleCancelDelete}>Закрыть</StyledButton>
        </div>
    );
}

export default DeleteModelForm; 