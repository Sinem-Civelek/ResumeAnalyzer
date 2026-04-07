import React, { useState } from "react";
import FileUpload from "./components/FileUpload";
import KeywordList from "./components/KeywordList";

function App() {
  const [keywords, setKeywords] = useState([]);

  return (
    <div style={{ padding: "2rem" }}>
      <h1>Resume Analyzer</h1>
      <FileUpload onKeywords={setKeywords} />
      <KeywordList keywords={keywords} />
    </div>
  );
}

export default App;