import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import VendingMachine from './VendingMachine.jsx'
import './index.css'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <VendingMachine />
  </StrictMode>,
)
