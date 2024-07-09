import React from 'react'
import Header from './Header'
import { useOutlet } from 'react-router-dom'

const WebsiteLayout = () => {
    const outlet = useOutlet()
    return (
        <div>
            <Header />
            <div className='container p-5'>
                {outlet}
            </div>
        </div>
    )
}

export default WebsiteLayout