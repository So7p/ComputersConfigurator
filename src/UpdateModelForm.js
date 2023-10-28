import React, { Component, useEffect, useState, useCallback } from 'react';
import StyledButton from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './CreateForm.css'

const getModelsURL = `https://localhost:7193/api/Models/get-models`;
const getConfigurationsURL = `https://localhost:7193/api/Configurations/get-configurations`;
const getComputerBrandsURL = `https://localhost:7193/api/ComputerBrands/get-computerBrands`; 

const updateModelURL = `https://localhost:7193/api/Models/update-model`;

function UpdateModelForm(props) {
    const [modelValues, setModelValues] = useState([]);
    const [nameValue, setNameValue] = useState('');
    const [configurationValues, setConfigurationValues] = useState([]);
    const [computerBrandValues, setComputerBrandValues] = useState([]);
    const [modelOptions, setModelOptions] = useState();
    const [configurationOptions, setConfigurationOptions] = useState();
    const [computerBrandOptions, setComputerBrandOptions] = useState();

    function handleUpdateModel() {
        const Model = {
            id: modelOptions?.id ?? 1,
            name: nameValue,
            configurationId: configurationOptions?.id ?? 1,
            computerBrandId: computerBrandOptions?.id ?? 1
        }

        axios
            .put(updateModelURL, Model)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelUpdate()
      }

    useEffect(()=>{
        fetch(getModelsURL).then((data)=>data.json()).then((val)=>setModelValues(val))
    },[])
    useEffect(()=>{
        fetch(getConfigurationsURL).then((data)=>data.json()).then((val)=>setConfigurationValues(val))
    },[])
    useEffect(() => {
        fetch(getComputerBrandsURL).then((data) => data.json()).then((val) => setComputerBrandValues(val));
      }, []);

    function handleCancelUpdate() {
        const updateModelForm = document.querySelector(".update-model-form");
        updateModelForm.style.display = "none";
    }

    return(
        <div className='update-form update-model-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Параметры модели
            </h5>
            <div className="data-components">
                <FormControl className="id-select-short" component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="model-label">Номер</InputLabel>
                    <Select labelId="model-label" label="Номер" variant="filled" value={modelOptions?.id ?? 1} onChange={(e) => setModelOptions(modelValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            modelValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.id}</MenuItem>))
                        }
                    </Select>
                </FormControl>

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
            <StyledButton className='confirm-update-button' variant="outlined" type='submit' onClick={handleUpdateModel}>Обновить</StyledButton>
            <StyledButton className='cancel-update-button' variant="outlined" type='submit' onClick={handleCancelUpdate}>Закрыть</StyledButton>
        </div>
    );
}

export default UpdateModelForm; 