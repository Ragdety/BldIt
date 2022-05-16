import React, {useEffect, useState} from 'react';
import './App.css';
import * as signalR from "@microsoft/signalr";
import {HubConnection} from "@microsoft/signalr";
import {sign} from "crypto";

function App() {
    const [connection, setConnection] = useState<HubConnection | null>();
    
    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl('https://localhost:5001/buildStream', {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets
            })
            .withAutomaticReconnect()
            .build();

        setConnection(connection);
    }, [])
    
    useEffect(() => {
        if(connection) {
            connection.start()
                .then((result: any) => {
                    console.log("Connected!");
                    connection.on("OutputReceived", message => {
                        console.log(message);
                    });
                })
                .catch((e: any) => console.log('Connection failed: ', e));
        }
    }, [connection])
    
  return (
    <div className="App">
      <header className="App-header">
        <nav>Nav here</nav>
        <main>Main here</main>
        <footer>Footer here</footer>
      </header>
    </div>
  );
}

export default App;
