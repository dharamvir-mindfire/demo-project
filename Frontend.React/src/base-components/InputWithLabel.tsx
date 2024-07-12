import React from 'react'

interface inputProps extends React.DetailedHTMLProps<React.InputHTMLAttributes<HTMLInputElement>, HTMLInputElement> {
    label?: string | React.ReactNode
}

const InputWithLabel = (props: inputProps) => {
    return (
        <div>
            {props?.label && <label htmlFor="userName" className="block text-sm font-medium leading-6 text-gray-900">{props?.label}</label>}
            <div className="mt-2">
                <input className={`block px-2 w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6 ${props?.className}`} {...props} />
            </div>
        </div>
    )
}

export default InputWithLabel