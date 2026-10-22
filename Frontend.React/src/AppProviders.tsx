import React from 'react'
import { ReduxProvider } from './store'
import { BrowserRouter as Router } from 'react-router-dom'

const Providers = ({ children }: any) => {
    return (
        <Router>
            <ReduxProvider>
                {children}
            </ReduxProvider>
        </Router>
    )
}
export default Providers