import React from "react";

import {
  Col,
  Container,
  Row
} from "reactstrap";

const Home: React.FC = () =>
  <Container>
    <h1 className="mb-4">Incident Management</h1>
    <Row>
      <Col>
        <p>
          An example React / .NET Core tool to record basic information about an incident that has occurred somewhere in the city.
          This example application demonstrates the following technologies and capabilities:
        </p>
        <ul>
          <li>.NET Core 3.1, React 16 with Hooks, TypeScript, ESLint, RESTful APIs, XUnit, Moq, Git</li>
          <li>SOLID and clean coding principles</li>
          <li>Front-end and back-end unit testing, including mocking</li>
          <li>Layered architecture, with clear separation of concerns</li>
        </ul>
      </Col>
    </Row>
  </Container>;

export default Home;