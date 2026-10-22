import React from 'react'
import { useOutlet } from 'react-router-dom'

const BaseLayout = () => {
    const outlet = useOutlet()
    return (
        <div>{outlet}</div>
    )
}

export default BaseLayout