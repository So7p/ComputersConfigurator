import React, { Component, useEffect, useState, useCallback, useRef, forwardRef } from 'react';
import StyledButton from '@mui/material/Button';
import { Select, MenuItem, InputLabel, FormControl } from '@mui/material';
import axios from 'axios';
import './DeleteForm.css';

const getComputersURL = `https://localhost:7193/api/Computers/get-computers`;
const deleteComputerURL = `https://localhost:7193/api/Computers/delete-computer/`;

function DeleteComputerForm(props) {
    const [computerValues, setComputerValues] = useState([]);
    const [computerOptions, setComputerOptions] = useState();

    function handleDeleteComputer() {
        const Computer = {
            id: computerOptions?.id,
        }

        axios
            .delete(deleteComputerURL + Computer.id)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        handleCancelDelete();
      }

    useEffect(()=>{
        fetch(getComputersURL).then((data)=>data.json()).then((val)=>setComputerValues(val))
    },[])  

    function handleCancelDelete() {
        const deleteComputerForm = document.querySelector(".delete-computer-form");
        deleteComputerForm.style.display = "none";
    }

    return(
        <div className='delete-form delete-computer-form' style={{ display: props.show ? "block" : "none" }}>
            <h5>
                Идентификатор компьютера
            </h5>
            <div className="data-components single-data-component">
                <FormControl className="id-select" component="form" autoComplete="off" variant="filled"> 
                    <InputLabel id="computer-label">Номер</InputLabel>
                    <Select labelId="computer-label" label="Номер" variant="filled" value={computerOptions?.id ?? 1} onChange={(e) => setComputerOptions(computerValues.find((c) => c.id === Number(e.target.value)))}>
                        {  
                            computerValues.map((opts) => (
                                <MenuItem key={opts.id} value={opts.id}>{opts.id}</MenuItem>))
                        }
                    </Select>
                </FormControl>
            </div>
            <StyledButton className='confirm-delete-button' variant="outlined" type='submit' onClick={handleDeleteComputer}>Удалить</StyledButton>
            <StyledButton className='cancel-delete-button' variant="outlined" type='submit' onClick={handleCancelDelete}>Закрыть</StyledButton>
        </div>
    );
} 

export default DeleteComputerForm