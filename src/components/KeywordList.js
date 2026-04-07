import React from "react";

const KeywordList = ({ keywords }) => {
  if (!keywords || keywords.length === 0)
    return <p>There is no analized words yet.</p>;

  return (
    <div>
      <h3>Found Analyzed Words:</h3>
      <ul>
        {keywords.map((k, i) => (
          <li key={i}>{k}</li>
        ))}
      </ul>
    </div>
  );
};

export default KeywordList;