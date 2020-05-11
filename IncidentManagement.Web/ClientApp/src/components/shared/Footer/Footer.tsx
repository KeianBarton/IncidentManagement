import React from "react";

const Footer: React.FC = () => {
  const year = new Date().getFullYear();

  return (
    <footer className="border-top">
      <p className="text-center py-3 m-0">
       © {year} Keian Barton
      </p>
    </footer>
  );
};

export default Footer;