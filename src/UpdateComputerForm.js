import React, { Component, useEffect, useState, useCallback } from 'react';
import StyledButton from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './UpdateForm.css'

const getComputersURL = `https://localhost:7193/api/Computers/get-computers`;
const getModelsURL = `https://localhost:7193/api/Models/get-models`;
const getComputerTypesURL = `https://localhost:7193/api/ComputerTypes/get-computerTypes`; 

const updateomputerURL = `https://localhost:7193/api/Computers/update-computer`;

function UpdateComputerForm(props) {
    const [computerValues, setComputerValues] = useState([]);
    const [modelValues, setModelValues] = useState([]);
    const [priceValue, setPriceValue] = useState('');
    const [quantityValue, setQuantityValue] = useState('');
    const [computerTypeValues, setComputerTypeValues] = useState([]);
    const [computerOptions, setComputerOptions] = useState();
    const [modelOptions, setModelOptions] = useState();
    const [computerTypeOptions, setComputerTypeOptions] = useState();

    function handleUpdateComputer() {
        const Computer = {
            id: computerOptions?.id ?? 1,
            modelId: modelOptions?.id ?? 1,
            price: priceValue,
            quantity: quantityValue,
            computerTypeId: computerTypeOptions?.id ?? 1
        }

        axios
            .put(updateomputerURL, Computer)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelUpdate();
      }

    useEffect(()=>{
        fetch(getComputersURL).then((data)=>data.json()).then((val)=>setComputerValues(val))
    },[])
    useEffect(()=>{
        fetch(getModelsURL).then((data)=>data.json()).then((val)=>setModelValues(val))
    },[])
    useEffect(() => {
        fetch(getComputerTypesURL).then((data) => data.json()).then((val) => setComputerTypeValues(val));
      }, []);

    function handleCancelUpdate() {
        const updateComputerForm = document.querySelector(".update-computer-form");
        updateComputerForm.style.display = "none";
    }

    return(
        <div className='update-form update-computer-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Параметры компьютера
            </h5>
            <div className="data-components">
            <FormControl className="id-select-short" component="form" autoComplete="off" variant="filled"> 
                <InputLabel id="computer-label">Номер</InputLabel>
                <Select labelId="computer-label" label="Номер" variant="filled" value={computerOptions?.id ?? 1} onChange={(e) => setComputerOptions(computerValues.find((c) => c.id === Number(e.target.value)))}>
                    {  
                        computerValues.map((opts) => (
                            <MenuItem key={opts.id} value={opts.id}>{opts.id}</MenuItem>))
                    }
                </Select>
            </FormControl> 

            <FormControl component="form" autoComplete="off" variant="filled"> 
                <InputLabel id="model-label">Модель</InputLabel>
                <Select labelId="model-label" label="Модель" variant="filled" value={modelOptions?.id ?? 1} onChange={(e) => setModelOptions(modelValues.find((c) => c.id === Number(e.target.value)))}>
                    {  
                        modelValues.map((opts) => (
                            <MenuItem key={opts.id} value={opts.id}>{opts.name}</MenuItem>))
                    }
                </Select>
            </FormControl>  

            <FormControl className="short-text-field" component="form" autoComplete="off" variant="filled">
                <TextField label="Цена" type="number" variant="filled" value={priceValue} onChange={(e) => setPriceValue(e.target.value)} />
            </FormControl>  

            <FormControl className="short-text-field" component="form" autoComplete="off" variant="filled">
                <TextField label="Количество" type="number" variant="filled" value={quantityValue} onChange={(e) => setQuantityValue(e.target.value)} />
            </FormControl> 

            <FormControl component="form" autoComplete="off" variant="filled">  
                <InputLabel id="type-label">Тип</InputLabel>
                <Select labelId="type-label" label="Тип" variant="filled" value={computerTypeOptions?.id ?? 1} onChange={(e) => setComputerTypeOptions(computerTypeValues.find((c) => c.id === Number(e.target.value)))}>
                    {  
                        computerTypeValues.map((opts) => (
                            <MenuItem key={opts.id} value={opts.id}>{opts.type}</MenuItem>))
                    }
                </Select>
            </FormControl>
            </div>
            <StyledButton className='confirm-update-button' variant="outlined" type='submit' onClick={handleUpdateComputer}>Обновить</StyledButton>
            <StyledButton className='cancel-update-button' variant="outlined" type='submit' onClick={handleCancelUpdate}>Закрыть</StyledButton>
        </div>
    );
}

export default UpdateComputerForm;