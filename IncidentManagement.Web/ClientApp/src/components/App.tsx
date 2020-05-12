import "./App.scss";

import React from "react";
import { Switch, Route } from "react-router";
import { NavMenu, Footer } from "./shared";
import { Home } from "./home";
import { AddIncident, ViewIncidents } from "./incidents";

const App: React.FC = () =>
  <>
    <NavMenu />
    <main id="app-main-vertical-fill" className="bg-light py-4">
      <Switch>
        <Route exact path="/" component={Home} />
        <Route exact path="/incidents/add" component={AddIncident} />
        <Route exact path="/incidents/view" component={ViewIncidents} />
        <Route component={Home} />
      </Switch>
    </main>
    <Footer />
  </>;

export default App;