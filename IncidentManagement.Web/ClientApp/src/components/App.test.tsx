import React from "react";
import { render, cleanup } from "@testing-library/react";
import App from "./App";
import { BrowserRouter } from "react-router-dom";
import "@testing-library/jest-dom/extend-expect";

describe("app component", (): void => {
  afterEach(cleanup);

  it("has a HTML5 main element that fills the screen correctly", (): void => {
    // Arrange
    expect.hasAssertions();
    const { container } = render(<BrowserRouter><App /></BrowserRouter>);
    const mainElements = container.getElementsByTagName("main");

    // Act / Assert
    expect(mainElements).toHaveLength(1);
    expect(mainElements[0]).toBeInTheDocument();
    expect(mainElements[0]).toHaveAttribute("id", "app-main-vertical-fill");
  });
})