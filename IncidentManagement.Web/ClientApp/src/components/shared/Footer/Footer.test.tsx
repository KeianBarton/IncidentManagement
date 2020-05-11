import React from "react";
import { render, cleanup } from "@testing-library/react";
import Footer from "./Footer";
import "@testing-library/jest-dom/extend-expect";

describe("footer component", (): void => {
  afterEach(cleanup);

  it("has a html5 footer element", (): void => {
    // Arrange
    expect.hasAssertions();
    const { container } = render(<Footer />);
    const footerElements = container.getElementsByTagName("footer");

    // Act / Assert
    expect(footerElements).toHaveLength(1);
    expect(footerElements[0]).toBeInTheDocument();
  })

  it("renders the current copyright year", (): void => {
    // Arrange
    expect.hasAssertions();
    const { getByText } = render(<Footer />);
    const currentYear = new Date().getFullYear();
    const textElement = getByText(new RegExp(`© ${currentYear} Keian Barton`));

    // Act / Assert
    expect(textElement).toBeInTheDocument();
  })
})