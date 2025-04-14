import React from 'react';

interface UploadFormProps {
  onImageChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  onQuestionChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  onSubmit: (event: React.FormEvent) => void;
  response: string;
  loading: boolean;
}

const UploadForm: React.FC<UploadFormProps> = ({ onImageChange, onQuestionChange, onSubmit, response, loading }) => {
  return (
    <form onSubmit={onSubmit} style={{ maxWidth: '600px', margin: '0 auto', padding: '20px', border: '1px solid #ccc', borderRadius: '8px', boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)', backgroundColor: '#f9f9f9' }}>
      <div style={{ marginBottom: '15px' }}>
        <label htmlFor="image" style={{ display: 'block', marginBottom: '5px', fontWeight: 'bold' }}>Upload Image:</label>
        <input type="file" id="image" onChange={onImageChange} required style={{ width: '100%', padding: '8px', border: '1px solid #ccc', borderRadius: '4px' }} />
      </div>
      <div style={{ marginBottom: '15px' }}>
        <label htmlFor="question" style={{ display: 'block', marginBottom: '5px', fontWeight: 'bold' }}>Question:</label>
        <input type="text" id="question" onChange={onQuestionChange} required style={{ width: '100%', padding: '8px', border: '1px solid #ccc', borderRadius: '4px' }} />
      </div>
      <button type="submit" disabled={loading} style={{ display: 'inline-block', padding: '10px 20px', fontSize: '16px', color: '#fff', backgroundColor: loading ? '#ccc' : '#0070f3', border: 'none', borderRadius: '4px', cursor: loading ? 'not-allowed' : 'pointer', transition: 'background-color 0.3s ease' }}>
        Submit
      </button>
      {loading && <img src="/loader.gif" alt="Loading..." style={{ display: 'block', margin: '20px auto' }} />}
      {response && (
        <div style={{ marginTop: '20px', padding: '15px', border: '1px solid #0070f3', borderRadius: '4px', backgroundColor: '#e6f7ff' }}>
          <h2 style={{ marginTop: '0' }}>Response:</h2>
          <p>{response}</p>
        </div>
      )}
    </form>
  );
};

export default UploadForm;