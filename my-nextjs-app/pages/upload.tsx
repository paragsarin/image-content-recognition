import { useState } from 'react';
import UploadForm from '../components/UploadForm';

const UploadPage = () => {
  const [image, setImage] = useState<File | null>(null);
  const [question, setQuestion] = useState('');
  const [response, setResponse] = useState<string>('');
  const [loading, setLoading] = useState<boolean>(false);

  const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files) {
      setImage(event.target.files[0]);
    }
  };

  const handleQuestionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setQuestion(event.target.value);
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    if (!image || !question) return;

    setLoading(true);

    const formData = new FormData();
    formData.append('image', image);
    formData.append('question', question);

    const response = await fetch(process.env.UPLOAD_API as string, {
      method: 'POST',
      body: formData,
    });


    if (response.ok) {
      const result = await response.json();
      const textResponse = result.messages[0].contents[0].text;
      setResponse(textResponse);
    } else {
      console.error('Error uploading image');
    }

    setLoading(false);
  };

  return (
    <div style={{ padding: '20px', backgroundColor: '#f0f2f5', minHeight: '100vh' }}>
      <h1 style={{ textAlign: 'center', color: '#333' }}>AI Tool-🤖Upload an image and ask a question about it.💻</h1>
      <UploadForm
        onImageChange={handleImageChange}
        onQuestionChange={handleQuestionChange}
        onSubmit={handleSubmit}
        response={response}
        loading={loading}
      />
    </div>
  );
};

export default UploadPage;