import logo from './logo.svg';
import './App.css';
import React, { Component, useEffect, useState, useCallback, useRef } from 'react';
import Carousel from 'react-bootstrap/Carousel';
import ReactDataGrid from '@inovua/reactdatagrid-community';
import '@inovua/reactdatagrid-community/index.css';
import CreateComputerForm from './CreateComputerForm';
import UpdateComputerForm from './UpdateComputerForm';
import DeleteComputerForm from './DeleteComputerForm';
import CreateModelForm from './CreateModelForm';
import UpdateModelForm from './UpdateModelForm';
import DeleteModelForm from './DeleteModelForm';
import CreateConfigForm from './CreateConfigForm';
import UpdateConfigForm from './UpdateConfigForm';
import DeleteConfigForm from './DeleteConfigForm';
import '@inovua/reactdatagrid-community/theme/amber-dark.css';
import Button from '@inovua/reactdatagrid-community/packages/Button';
import StyledButton from '@mui/material/Button';
import NumberFilter from '@inovua/reactdatagrid-community/NumberFilter';
import SelectFilter from '@inovua/reactdatagrid-community/SelectFilter';
import NumericEditor from '@inovua/reactdatagrid-community/NumericEditor';
import BoolEditor from '@inovua/reactdatagrid-community/BoolEditor';
import SelectEditor from '@inovua/reactdatagrid-community/SelectEditor';

const gridStyle = { marginTop: 10, minHeight: 550, textAlign: 'center' }

const computerFilterValue = [
  {name: 'id', operator: 'inrange', type: 'number', value: { start: 1, end: 1000 } },
  {name: 'modelName', operator: 'contains', type: 'string', value: '' },
  {name: 'price', operator: 'inrange', type: 'number', value: { start: 1, end: 50000 } },
  {name: 'quantity', operator: 'inrange', type: 'number', value: { start: 1, end: 1000 } },
  {name: 'type', operator: 'contains', value: '' }
]

const modelFilterValue = [
  {name: 'id', operator: 'inrange', type: 'number', value: { start: 1, end: 1000 } },
  {name: 'computerBrandName', operator: 'contains', type: 'string', value: '' },
  {name: 'name', operator: 'contains', type: 'string', value: '' },
  {name: 'configurationId', operator: 'inrange', type: 'number', value: { start: 1, end: 1000 } }
]

const configurationFilterValue = [
  {name: 'id', operator: 'inrange', type: 'number', value: { start: 1, end: 1000 } },
  {name: 'cpu', operator: 'contains', type: 'string', value: '' },
  {name: 'gpu', operator: 'contains', type: 'string', value: '' },
  {name: 'ram', operator: 'contains', type: 'string', value: '' },
  {name: 'drive', operator: 'contains', type: 'string', value: '' }
]

const computerColumns = [
  { name: 'id', header: 'Идентификатор', defaultVisible: true, defaultFlex: 3, type: 'number', filterEditor: NumberFilter },
  { name: 'modelName', header: 'Модель', defaultFlex: 3, type: 'string' },
  { name: 'price', header: 'Цена, руб.', defaultFlex: 3, type: 'number', filterEditor: NumberFilter, editor: NumericEditor },
  { name: 'quantity', header: 'Количество', defaultFlex: 3, type: 'number', filterEditor: NumberFilter, editor: NumericEditor },
  { name: 'type', header: 'Тип', defaultFlex: 3, type: 'string' }
];

const modelColumns = [ 
  { name: 'id', header: 'Идентификатор', defaultVisible: true, defaultFlex: 3, type: 'number', filterEditor: NumberFilter },
  { name: 'computerBrandName', header: 'Бренд', defaultFlex: 3, type: 'strig',  },
  { name: 'name', header: 'Название модели', defaultFlex: 3, type: 'string' },
  { name: 'configurationId', header: 'Номер конфигурации', defaultFlex: 3, type: 'number', filterEditor: NumberFilter, editor: NumericEditor }
];

const configurationColumns = [ 
  { name: 'id', header: 'Идентификатор', defaultVisible: true, defaultFlex: 3, type: 'number', filterEditor: NumberFilter },
  { name: 'cpu', header: 'Процессор (CPU)', defaultFlex: 3, type: 'string' },
  { name: 'gpu', header: 'Видеокарта (GPU)', defaultFlex: 3, type: 'string' },
  { name: 'ram', header: 'ОЗУ (RAM)', defaultFlex: 3, type: 'string' },
  { name: 'drive', header: 'Накопитель', defaultFlex: 3, type: 'string' }
];


const computerURL = `https://localhost:7193/api/Computers/get-computers`;
const modelURL = `https://localhost:7193/api/Models/get-models`;
const configurationURL = `https://localhost:7193/api/Configurations/get-configurations`;


const GetComputers = () => {
  const [dataSource, setDataSource] = useState([]);
  const [columns] = useState(computerColumns);

  const loadData = useCallback(() => {
    const newDataSource = () => {
      return fetch(computerURL)
        .then(response => {
          const totalCount = response.headers.get('X-Total-Count');
          return response.json().then(data => {
            return { data, count: totalCount * 1 };
          })
        });
      }
      setDataSource(newDataSource)
  }, []);

  const onEditComplete = useCallback(({value, columnId, rowId}) => {
    const data = [...dataSource];
    data[rowId] = Object.assign({}, data[rowId], {[columnId]: value})

    return setDataSource(data);
  }, [dataSource]);

  const [showCreateComputerForm, setShowCreateComputerForm] = useState(false);
  const [showUpdateComputerForm, setShowUpdateComputerForm] = useState(false);
  const [showDeleteComputerForm, setShowDeleteComputerForm] = useState(false);

  return (
    <div> 
      <h2>Компьютеры</h2>

      <CreateComputerForm show={showCreateComputerForm} id="CreateComputerForm" />
      <UpdateComputerForm show={showUpdateComputerForm} id="UpdateComputerForm" />
      <DeleteComputerForm show={showDeleteComputerForm} id="DeleteComputerForm" />

      <StyledButton onClick={() => loadData()} style={{marginRight: 10}} variant="contained">
        Обновить
      </StyledButton>
      <StyledButton disabled={Array.isArray(dataSource)} onClick={() => setDataSource([])} style={{marginRight: 40}} variant="contained">
        Очистить
      </StyledButton>
      <StyledButton className="create-window-button" disabled={Array.isArray(dataSource)} style={{marginRight: 10}} variant="contained" onClick={() => setShowCreateComputerForm(!showCreateComputerForm)}> 
        Создать
      </StyledButton>
      <StyledButton className="update-window-button" disabled={Array.isArray(dataSource)} style={{marginRight: 10}} variant="contained" onClick={() => setShowUpdateComputerForm(!showUpdateComputerForm)}> 
        Изменить
      </StyledButton>
      <StyledButton className="delete-window-button" disabled={Array.isArray(dataSource)} variant="contained" onClick={() => setShowDeleteComputerForm(!showDeleteComputerForm)}>  
        Удалить
      </StyledButton>

      <ReactDataGrid
        style={gridStyle}
        idProperty="id"
        enableFiltering={true}
        defaultFilterValue={computerFilterValue}
        onEditComplete={onEditComplete}
        editable={false}
        columns={columns}
        dataSource={dataSource}
      />
    </div>
  );
};

const GetModels = () => {
  const [dataSource, setDataSource] = useState([]);
  const [columns] = useState(modelColumns);

  const loadData = useCallback(() => {
    const newDataSource = () => {
      return fetch(modelURL)
        .then(response => {
          const totalCount = response.headers.get('X-Total-Count');
          return response.json().then(data => {
            return { data, count: totalCount * 1 };
          })
        });
      }
      setDataSource(newDataSource)
  }, []);

  const [showCreateModelForm, setShowCreateModelForm] = useState(false);
  const [showUpdateModelForm, setShowUpdateModelForm] = useState(false);
  const [showDeleteModelForm, setShowDeleteModelForm] = useState(false);

  return (
    <div>
      <h2>Модели</h2>

      <CreateModelForm show={showCreateModelForm} id="CreateModelForm" />
      <UpdateModelForm show={showUpdateModelForm} id="UpdateModelForm" />
      <DeleteModelForm show={showDeleteModelForm} id="DeleteModelForm" />

      <StyledButton onClick={() => loadData()} style={{marginRight: 10}} variant="contained">
        Обновить
      </StyledButton>
      <StyledButton disabled={Array.isArray(dataSource)} onClick={() => setDataSource([])} style={{marginRight: 40}} variant="contained"> 
        Очистить
      </StyledButton>
      <StyledButton className="create-window-button" disabled={Array.isArray(dataSource)} style={{marginRight: 10}} variant="contained" onClick={() => setShowCreateModelForm(!showCreateModelForm)}> 
        Создать
      </StyledButton>
      <StyledButton className="update-window-button" disabled={Array.isArray(dataSource)} style={{marginRight: 10}} variant="contained" onClick={() => setShowUpdateModelForm(!showUpdateModelForm)}> 
        Изменить
      </StyledButton>
      <StyledButton className="delete-window-button" disabled={Array.isArray(dataSource)} variant="contained" onClick={() => setShowDeleteModelForm(!showDeleteModelForm)}> 
        Удалить
      </StyledButton>

      <ReactDataGrid
        style={gridStyle}
        idProperty="id"
        enableFiltering={true}
        defaultFilterValue={modelFilterValue}
        editable={false}
        columns={columns}
        dataSource={dataSource}
      />
    </div>
  );
};

const GetConfigurations = () => {
  const [dataSource, setDataSource] = useState([]);
  const [columns] = useState(configurationColumns);

  const loadData = useCallback(() => {
    const newDataSource = () => {
      return fetch(configurationURL)
        .then(response => {
          const totalCount = response.headers.get('X-Total-Count');
          return response.json().then(data => {
            return { data, count: totalCount * 1 };
          })
        });
      }
      setDataSource(newDataSource)
  }, []);

  const [showCreateConfigForm, setShowCreateConfigForm] = useState(false);
  const [showUpdateConfigForm, setShowUpdateConfigForm] = useState(false);
  const [showDeleteConfigForm, setShowDeleteConfigForm] = useState(false);

  return (
    <div>
      <h2>Конфигурации</h2>

      <CreateConfigForm show={showCreateConfigForm} id="CreateConfigForm" />
      <UpdateConfigForm show={showUpdateConfigForm} id="UpdateConfigForm" />
      <DeleteConfigForm show={showDeleteConfigForm} id="DeleteConfigForm" />

      <StyledButton onClick={() => loadData()} style={{marginRight: 10}} variant="contained">
        Обновить
      </StyledButton>
      <StyledButton disabled={Array.isArray(dataSource)} onClick={() => setDataSource([])} style={{marginRight: 40}} variant="contained">
        Очистить
      </StyledButton>
      <StyledButton className="create-window-button" disabled={Array.isArray(dataSource)} style={{marginRight: 10}} variant="contained" onClick={() => setShowCreateConfigForm(!showCreateConfigForm)}> 
        Создать
      </StyledButton>
      <StyledButton className="update-window-button" disabled={Array.isArray(dataSource)} style={{marginRight: 10}} variant="contained" onClick={() => setShowUpdateConfigForm(!showUpdateConfigForm)}> 
        Изменить
      </StyledButton>
      <StyledButton className="delete-window-button" disabled={Array.isArray(dataSource)} variant="contained" onClick={() => setShowDeleteConfigForm(!showDeleteConfigForm)}> 
        Удалить
      </StyledButton>

      <ReactDataGrid
        style={gridStyle}
        idProperty="id"
        enableFiltering={true}
        defaultFilterValue={configurationFilterValue}
        editable={false}
        columns={columns}
        dataSource={dataSource}
      />
    </div>
  );
};

const App = () => {
  return(
    <div className="App">
      <h1>Конфигуратор компьютеров</h1>
      <div className="App-content">
          <Carousel interval = {null}>
            <Carousel.Item>
              {GetComputers()}
            </Carousel.Item>

            <Carousel.Item>
              {GetModels()}
            </Carousel.Item>

            <Carousel.Item>
              {GetConfigurations()}
            </Carousel.Item>
          </Carousel>
      </div>
    </div>

  );
}

export default () => <App/>;