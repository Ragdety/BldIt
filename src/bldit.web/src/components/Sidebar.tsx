import React, { useState } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { BsBoxArrowInLeft, BsDoorOpenFill } from "react-icons/bs";
import { VscGraph } from 'react-icons/vsc';
import { IoMdSettings } from 'react-icons/io';
import { GiGearStickPattern } from 'react-icons/gi';
import { MdBuild } from 'react-icons/md';
import { MdAccountCircle } from 'react-icons/md';

const SideBar = () => {
    //This will be coming from context
    let activeMenu = true;
    
    const activeLink = 'flex items-center gap-5 pl-4 ' +
                       'pt-3 pb-2.5 rounded-lg text-white text-md m-2'
    const normalLink = 'gap-5 pl-4 rounded-lg text-white text-md text-gray-700 ' +
                       'dark:text-gray-200 hover:text-black hover:bg-light-gray m-2'
    
    const Links = [
        { title: "Dashboard", path: "dashboard", icon: (<VscGraph/>)},
        { title: "Accounts",  path: "accounts", icon: (<MdAccountCircle/>), gap: true},
        { title: "Configure", path: "configure", icon: (<IoMdSettings/>)},
        { title: "Projects",  path: "projects", icon: (<BsDoorOpenFill/>), gap: true},
        { title: "Jobs",      path: "jobs", icon: (<GiGearStickPattern/>)},
        { title: "Builds",    path: "builds", icon: (<MdBuild/>)},
    ]
    
    return (
        <div className="ml-3 md:overflow-hidden overflow-auto pb-10">
            <BsBoxArrowInLeft
                className={`${!activeMenu && "rotate-180"} absolute cursor-pointer right-5
                                   top-9 w7 text-white`} 
            onClick={() => activeMenu = !activeMenu} 
            />
            <div className="flex gap-x-4 items-center">
                <h1 className={`text-white origin-left font-medium text-xl
                            duration-200 ${!activeMenu && 'scale-0'}`}>
                    BldIt
                </h1>
            </div>
            <ul className="pt-6">
                {Links.map((menu, index) => (
                    <li key={index} 
                        className={`text-gray-300 text-sm flex items-center 
                                   gap-x-4 cursor-pointer p-2 hover:bg-light-white
                                   rounded-md ${menu.gap ? "mt-9" : "mt-2"}`}>
                        <span>{menu.icon}</span>
                        <span className={`${!activeMenu && 'hidden'} origin-left duration-200`}>{menu.title}</span>
                        <NavLink to={`/${menu.path}`} 
                                 key={menu.title}
                                 onClick={() => {}}
                                 className={({ isActive }) => isActive ? activeLink : normalLink}
                        />
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default SideBar;