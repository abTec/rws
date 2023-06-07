import './App.css'
import { Button, Container, Typography } from '@mui/material'
import { useState } from 'react';
import { ToastContainer, toast } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import Translator from './Translator';
import TranslatorList from './Components/TranslatorList';

function App() {
  
  const [isLoading, setIsLoading] = useState<boolean>(false)
  const [data, setData] = useState<Translator[]>([])

  const handleClick = async () => {
    setIsLoading(true);

    try {
      const response = await fetch('api/TranslatorsManagement/GetTranslators', {
        method: 'GET',
        headers: {
          Accept: 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`Oops! status: ${response.status}`);
      }
  
      const result = await response.json();

      setData(result)

      toast.success('Success!', {
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: 'dark',
      })
    } catch (err) {
      toast.success('Success!', {
        type: 'error',
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: 'dark',
      })
    } finally {
      setIsLoading(false);
    }
  }


  return (
        <Container maxWidth="sm" className='App'>
          <Typography variant="h1" gutterBottom>RWS Client</Typography>
          <Button
                  disabled={isLoading}
                  onClick={handleClick}
                  variant="outlined">Get Translators</Button>
          <TranslatorList translators={data} />
          <ToastContainer />
        </Container>
  )
}

export default App