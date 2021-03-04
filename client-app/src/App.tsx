import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';


function App() {
  const [activitives, setActivities] = useState([]);

  // fetch activities using API
  useEffect(() => {
    // will return a promise function to execute
    axios.get('http://localhost:5000/api/activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  }, [])
  return (
    <div>
      <Header as='h2' icon = 'users' content='Reactivities' />
      <List>
          {activitives.map((activity:any) => (
            <List.Item key={activity.id}>{activity.title}</List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
