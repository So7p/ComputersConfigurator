import React, { Component, useEffect, useState, useCallback } from 'react';
import StyledButton from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './CreateForm.css'

const getConfigurationsURL = `https://localhost:7193/api/Configurations/get-configurations`;
const getComputerBrandsURL = `https://localhost:7193/api/ComputerBrands/get-computerBrands`; 

const createModelURL = `https://localhost:7193/api/Models/create-model`;

function CreateModelForm(props) {
    const [nameValue, setNameValue] = useState('');
    const [configurationValues, setConfigurationValues] = useState([]);
    const [computerBrandValues, setComputerBrandValues] = useState([]);
    const [configurationOptions, setConfigurationOptions] = useState();
    const [computerBrandOptions, setComputerBrandOptions] = useState();

    function handleAddModel() {
        const Model = {
            name: nameValue,
            configurationId: configurationOptions?.id ?? 1,
            computerBrandId: computerBrandOptions?.id ?? 1
        }

        axios
            .post(createModelURL, Model)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelCreate()
      }

    useEffect(()=>{
        fetch(getConfigurationsURL).then((data)=>data.json()).then((val)=>setConfigurationValues(val))
    },[])
    useEffect(() => {
        fetch(getComputerBrandsURL).then((data) => data.json()).then((val) => setComputerBrandValues(val));
      }, []);

    function handleCancelCreate() {
        const createModelForm = document.querySelector(".create-model-form");
        createModelForm.style.display = "none";
    }

    return(
        <div className='create-form create-model-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Параметры модели
            </h5>
            <div className="data-components">
                <FormControl component="form" autoComplete="off" variant="filled">
                    <TextField label="Название модели" type="text" variant="filled" value={nameValue} onChange={(e) => setNameValue(e.target.value)} />
                </FormControl>  

                <FormControl className="id-select-large" component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="config-label">Номер конфигурации</InputLabel>
                    <Select labelId="config-label" label="Номер конфигурации" variant="filled" value={configurationOptions?.id ?? 1} onChange={(e) => setConfigurationOptions(configurationValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            configurationValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.id}</MenuItem>))
                        }
                    </Select>
                </FormControl> 

                <FormControl component="form" autoComplete="off" variant="filled">  
                    <InputLabel id="brand-label">Бренд</InputLabel>
                    <Select labelId="brand-label" label="Бренд" variant="filled" value={computerBrandOptions?.id ?? 1} onChange={(e) => setComputerBrandOptions(computerBrandValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            computerBrandValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.name}</MenuItem>))
                        }
                    </Select>
                </FormControl>
            </div>
            <StyledButton className='confirm-create-button' variant="outlined" type='submit' onClick={handleAddModel}>Добавить</StyledButton>
            <StyledButton className='cancel-create-button' variant="outlined" type='submit' onClick={handleCancelCreate}>Закрыть</StyledButton>
        </div>
    );
}

export default CreateModelForm; 