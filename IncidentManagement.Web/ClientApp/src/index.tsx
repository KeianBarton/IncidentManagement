import "./index.scss";

import App from "./components/App";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href") || undefined;
const rootElement = document.getElementById("root");

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

// If you want your app to work offline and load faster, you can register a
// service worker below. Note this comes with some pitfalls.
// Learn more about service workers:
// https://create-react-app.dev/docs/making-a-progressive-web-app/
// https://developers.google.com/web/fundameentals/primers/service-workers
// serviceWorker.register();