import "./App.scss";

import React from "react";
import { Switch, Route } from "react-router";
import { NavMenu, Footer } from "./shared";
import { Home } from "./home";

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
  </>;

export default App;