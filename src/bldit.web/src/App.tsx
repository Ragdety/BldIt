import React, {useEffect, useState} from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import {Navbar, Footer, Sidebar, ThemeSettings} from "./components";
import {BldIt, Projects} from "./pages";

import './App.css';

import * as signalR from "@microsoft/signalr";
import {HubConnection} from "@microsoft/signalr";

function App() {
    const [connection, setConnection] = useState<HubConnection | null>();
    
    const activeMenu = true;
    const buildStreamURL: string = process.env.REACT_APP_BLDIT_BUILD_STREAM_URL_SECURE!;

    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl(buildStreamURL, {
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
        <div>
            <BrowserRouter>
                <div className="flex dark:bg-main-dark-bg">
                    <div className={`${activeMenu ? "w-72" : "w-20"} relative 
                                    h-screen sidebar dark:bg-secondary-dark-bg bg-dark-purple
                                    duration-200 p-5 pt-8`}>
                        <Sidebar />
                    </div>
                    <div className={
                        `dark:bg-main-bg bg-main-bg min-h-screen w-full
                        ${activeMenu ? " md:ml-72" : "flex-2"}`
                    }>
                        <div className="fixed md:static bg-main-bg dark:bg-main-dark-bg navbar w-full">
                            <Navbar />
                        </div>
                    </div>
                    <div>
                        <Routes>
                            {/* Dashboard */}
                            <Route path="/" element={<BldIt/>} />
                            <Route path="/bldIt" element={<BldIt/>} />

                            {/* Pages */}
                            <Route path="/projects" element={<Projects/>} />
                        </Routes>
                    </div>
                </div>
            </BrowserRouter>
        </div>
    );
}

export default App;