import React from 'react';
import ReactDOM from 'react-dom/client'
import "./index.css";
import { RouterProvider } from 'react-router-dom';
import { router } from './utilities/router';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <RouterProvider router={router} future={{ v7_startTransition: true}}/>
);