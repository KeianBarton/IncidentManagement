import React from "react";
import GoogleMapReact from "google-map-react";

import {
  Col,
  Container,
  Row
} from "reactstrap";

const ViewIncidents: React.FC = () => {
  // Defaults to London
  const defaultMapCenter = {
    lat: 51.5049664,
    lng: -0.1153235
  };
  const defaultMapZoom = 12;

  return (
    <Container className="h-100 d-flex flex-column"> {/* We use flexing for Google Map to render correctly */}
      <h1 className="mb-4">View Incidents</h1>
      <Row className="flex-grow-1"> 
        <Col>
          <div className="border h-100">
            <GoogleMapReact
              bootstrapURLKeys={{ key: process.env.REACT_APP_GOOGLE_MAPS_API_KEY as string }}
              defaultCenter={defaultMapCenter}
              defaultZoom={defaultMapZoom}
            ></GoogleMapReact>
          </div>
        </Col>
      </Row>
    </Container>
  );
};

export default ViewIncidents;