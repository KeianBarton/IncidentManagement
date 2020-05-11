import "./App.scss";

import React, { Component } from "react";
import { Switch, Route } from "react-router";
import { NavMenu, Footer } from "./shared";
import { Home } from "./home";
import { ToastContainer } from "react-toastify";

const App: React.FC = () =>
  <>
    <NavMenu />
    <main id="app-main-vertical-fill" className="bg-light py-4">
      <Switch>
        <Route exact path="/" component={Home} />
        <Route component={Home} />
      </Switch>
    </main>
    <Footer />
    <ToastContainer
      autoClose
      closeOnClick={false}
      draggable={false}
      newestOnTop
      position="top-right"
      rtl={false}
    />
  </>;

export default App;