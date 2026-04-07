import React, { useState } from "react";
import axios from "axios";

const FileUpload = ({ onKeywords }) => {
  const [file, setFile] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleFileChange = (e) => {
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    if (!file) return alert("Please select a document.");

    setLoading(true);
    const formData = new FormData();
    formData.append('file', file);

    try {
      const res = await axios.post(
        "https://localhost:7128/api/resume/upload",
        formData,
        { headers: { "Content-Type": "multipart/form-data" } }
      );
      onKeywords(res.data.keywords || []);
    } catch (err) {
      console.error(err);
      alert("Problem occurred while uploading/analyzing");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <input type="file" accept=".pdf,.docx" onChange={handleFileChange} />
      <button onClick={handleUpload} disabled={loading}>
        {loading ? "Analyzing..." : "Upload and Analyze"}
      </button>
    </div>
  );
};

export default FileUpload;