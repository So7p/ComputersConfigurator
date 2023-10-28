import React, { Component, useEffect, useState, useCallback } from 'react';
import StyledButton from '@mui/material/Button';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './CreateForm.css'

const getCPUsURL = `https://localhost:7193/api/CPUs/get-CPUs`;
const getGPUsURL = `https://localhost:7193/api/GPUs/get-GPUs`;
const getRAMsURL = `https://localhost:7193/api/RAMs/get-RAMs`;
const getDrivesURL = `https://localhost:7193/api/Drives/get-Drives`;

const createConfigurationURL = `https://localhost:7193/api/Configurations/create-configuration`;

function CreateConfigForm(props) {
    const [cpuValues, setCpuValues] = useState([]);
    const [gpuValues, setGpuValues] = useState([]);
    const [ramValues, setRamValues] = useState([]);
    const [driveValues, setDriveValues] = useState([]);
    const [cpuOptions, setCpuOptions] = useState();
    const [gpuOptions, setGpuOptions] = useState();
    const [ramOptions, setRamOptions] = useState();
    const [driveOptions, setDriveOptions] = useState();

    function handleAddConfig() {
        const Config = {
            cpuId: cpuOptions?.id ?? 1,
            gpuId: gpuOptions?.id ?? 1,
            ramId: ramOptions?.id ?? 1,
            driveId: driveOptions?.id ?? 1
        }

        axios
            .post(createConfigurationURL, Config)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelCreate()
      }

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

    function handleCancelCreate() {
        const createConfigForm = document.querySelector(".create-config-form");
        createConfigForm.style.display = "none";
    }

    return(
        <div className='create-form create-config-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Параметры конфигурации
            </h5>
            <div className="data-components create-config-data-components">
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
            <StyledButton className='confirm-create-button' variant="outlined" type='submit' onClick={handleAddConfig}>Добавить</StyledButton>
            <StyledButton className='cancel-create-button' variant="outlined" type='submit' onClick={handleCancelCreate}>Закрыть</StyledButton>
        </div>
    );
}

export default CreateConfigForm;