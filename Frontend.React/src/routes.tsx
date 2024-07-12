import * as React from "react";
import Login from './pages/Login'
import Registration from './pages/Registration'
import BaseLayout from "./layouts/BaseLayout";
import { Navigate, RouteObject } from "react-router-dom";
import Home from "./pages/Home";
import WebsiteLayout from "./layouts/WebsiteLayout";

const routes = (isLoggedIn: boolean = false): RouteObject[] => {
    if (!isLoggedIn) {
        return [
            {
                path: '*',
                element: <Navigate to="/" />
            },
            {
                path: "/",
                element: <BaseLayout />,
                children: [
                    {
                        path: '/',
                        element: <Navigate to="login" />
                    },
                    {
                        path: "login",
                        element: <Login />,
                    },
                    { path: "register", element: <Registration /> },
                ],
            },
        ]
    } else {
        return [{
            path: "/",
            element: <WebsiteLayout />,
            children: [
                {
                    path: '*',
                    element: <Navigate to="/" />
                },
                {
                    path: "",
                    element: <Home />,
                },
            ],
        }]
    }
};

export default routes