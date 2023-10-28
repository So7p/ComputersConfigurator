import React, { Component, useEffect, useState, useCallback } from 'react';
import StyledButton from '@mui/material/Button';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './UpdateForm.css'

const getConfigurationsURL = `https://localhost:7193/api/Configurations/get-configurations`;
const getCPUsURL = `https://localhost:7193/api/CPUs/get-CPUs`;
const getGPUsURL = `https://localhost:7193/api/GPUs/get-GPUs`;
const getRAMsURL = `https://localhost:7193/api/RAMs/get-RAMs`;
const getDrivesURL = `https://localhost:7193/api/Drives/get-Drives`;

const updateConfigurationURL = `https://localhost:7193/api/Configurations/update-configuration`;

function UpdateConfigForm(props) {
    const [configurationValues, setConfigurationValues] = useState([]);
    const [cpuValues, setCpuValues] = useState([]);
    const [gpuValues, setGpuValues] = useState([]);
    const [ramValues, setRamValues] = useState([]);
    const [driveValues, setDriveValues] = useState([]);
    const [configurationOptions, setConfigurationOptions] = useState();
    const [cpuOptions, setCpuOptions] = useState();
    const [gpuOptions, setGpuOptions] = useState();
    const [ramOptions, setRamOptions] = useState();
    const [driveOptions, setDriveOptions] = useState();

    function handleUpdateConfig() {
        const Config = {
            id: configurationOptions?.id ?? 1,
            cpuId: cpuOptions?.id ?? 1,
            gpuId: gpuOptions?.id ?? 1,
            ramId: ramOptions?.id ?? 1,
            driveId: driveOptions?.id ?? 1
        }

        axios
            .put(updateConfigurationURL, Config)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelUpdate();
      }

    useEffect(()=>{
        fetch(getConfigurationsURL).then((data)=>data.json()).then((val)=>setConfigurationValues(val))
    },[])  
    useEffect(()=>{
        fetch(getCPUsURL).then((data)=>data.json()).then((val)=>setCpuValues(val))
    },[])
    useEffect(() => {
        fetch(getGPUsURL).then((data) => data.json()).then((val) => setGpuValues(val));
      }, []);
    useEffect(() => {
        fetch(getRAMsURL).then((data) => data.json()).then((val) => setRamValues(val));
    }, []);
    useEffect(() => {
        fetch(getDrivesURL).then((data) => data.json()).then((val) => setDriveValues(val));
    }, []);

    function handleCancelUpdate() {
        const updateConfigForm = document.querySelector(".update-config-form");
        updateConfigForm.style.display = "none";
    }

    return(
        <div className='update-form update-config-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Параметры конфигурации
            </h5>
            <div className="data-components update-config-data-components">
                <FormControl className="id-select-short" component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="config-label">Номер</InputLabel>
                    <Select labelId="config-label" label="Номер" variant="filled" value={configurationOptions?.id ?? 1} onChange={(e) => setConfigurationOptions(configurationValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            configurationValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.id}</MenuItem>))
                        }
                    </Select>
                </FormControl>

                <FormControl component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="cpu-label">Процессор</InputLabel>
                    <Select labelId="cpu-label" label="Процессор" variant="filled" value={cpuOptions?.id ?? 1} onChange={(e) => setCpuOptions(cpuValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            cpuValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.name}</MenuItem>))
                        }
                    </Select>
                </FormControl>  

                <FormControl component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="gpu-label">Видеокарта</InputLabel>
                    <Select labelId="gpu-label" label="Видеокарта" variant="filled" value={gpuOptions?.id ?? 1} onChange={(e) => setGpuOptions(gpuValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            gpuValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.name}</MenuItem>))
                        }
                    </Select>
                </FormControl>

                <FormControl component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="ram-label">ОЗУ</InputLabel>
                    <Select labelId="ram-label" label="ОЗУ" variant="filled" value={ramOptions?.id ?? 1} onChange={(e) => setRamOptions(ramValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            ramValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.name}</MenuItem>))
                        }
                    </Select>
                </FormControl>

                <FormControl component="form" autoComplete="off" variant="filled">  
                    <InputLabel id="drive-label">Накопитель</InputLabel>
                    <Select labelId="drive-label" label="Накопитель" variant="filled" value={driveOptions?.id ?? 1} onChange={(e) => setDriveOptions(driveValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            driveValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.name}</MenuItem>))
                        }
                    </Select>
                </FormControl>
            </div>
            <StyledButton className='confirm-update-button' variant="outlined" type='submit' onClick={handleUpdateConfig}>Обновить</StyledButton>
            <StyledButton className='cancel-update-button' variant="outlined" type='submit' onClick={handleCancelUpdate}>Закрыть</StyledButton>
        </div>
    );
}

export default UpdateConfigForm;