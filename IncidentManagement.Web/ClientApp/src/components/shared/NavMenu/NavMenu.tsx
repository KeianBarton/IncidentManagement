import React, { useState } from "react";
// eslint-disable-next-line no-unused-vars
import { NavLink as RRNavLink, Route } from "react-router-dom";
import {
  Collapse,
  DropdownItem,
  DropdownToggle,
  Nav,
  Navbar,
  NavbarBrand,
  NavItem,
  NavbarToggler,
  // eslint-disable-next-line no-unused-vars, import/named
  NavLinkProps,
  UncontrolledDropdown,
  DropdownMenu
} from "reactstrap";

const NavMenu: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);
  // Figured this out using:
  // https://stackoverflow.com/questions/49962495/integrate-react-router-active-navlink-with-child-component
  const CustomNavLinkWithoutAnchorTag: React.FC<NavLinkProps> = ({ to, activeClassName, children }) => {
    const path = typeof to === "object" ? to.pathname : to;
    return <Route
      path={path}
      // eslint-disable-next-line react/no-children-prop
      children={({ match }): JSX.Element => {
        const isActive = !!match;
        return <p className={`mb-0 ${isActive ? activeClassName : ""}`}>{children}</p>;
      }}
    />;
  };
  return (
    <header>
      <Navbar light expand="md" className="border-bottom">
        <NavbarBrand tag={RRNavLink} to="/" className="p-0">
          <b>Incident Management</b>
        </NavbarBrand>
        <NavbarToggler onClick={(): void => setIsOpen(!isOpen)} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <UncontrolledDropdown nav inNavbar>
              {/* The following custom component structure is needed to stop a nested <a> tag hierarchy which is bad practice in React */}
              <NavItem tag={CustomNavLinkWithoutAnchorTag} to="/incidents" activeClassName="active">
                <DropdownToggle nav caret>
                  Incidents
                </DropdownToggle>
              </NavItem>
              <DropdownMenu direction="left">
                <DropdownItem tag={RRNavLink} exact to="/incidents/add" activeClassName="active">
                  Add Incident
                </DropdownItem>
                <DropdownItem tag={RRNavLink} exact to="/incidents/view" activeClassName="active">
                  View Incidents
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
          </Nav>
        </Collapse>
      </Navbar>
    </header>
  );
};

export default NavMenu;