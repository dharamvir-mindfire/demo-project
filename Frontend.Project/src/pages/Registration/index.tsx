import React, { useState } from 'react'
import { useRegisterMutation } from '../../services/authServices';
import { Link } from 'react-router-dom';
import InputWithLabel from '../../base-components/InputWithLabel';
import Alert from '../../base-components/Alert';

const Registration = () => {
    const [registerUser] = useRegisterMutation();
    const [alert, setAlert] = useState({ title: "", message: '' })
    const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        var formData = new FormData(event.currentTarget)
        const payload: any = {
            fullName: formData.get("fullName"),
            email: formData.get("email"),
            phoneNumber: formData.get("phoneNumber"),
            password: formData.get("password"),
        }
        registerUser(payload).then((res) => {
            if (!res?.error) {
                setAlert({
                    title: 'Success',
                    message: "Registered Successfully"
                })
            } else {
                setAlert({
                    title: 'Failed',
                    message: "Failed to register"
                })
            }
        }).catch(() => { })
    }
    return (
        <div className="flex min-h-full flex-col justify-center px-6 py-6 lg:px-8">
            <div className="sm:mx-auto sm:w-full sm:max-w-sm">
                <img className="mx-auto h-10 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600" alt="Your Company" />
                <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">New Registration</h2>
            </div>

            <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
                <Alert visible={Boolean(alert?.message)} {...alert} onRequestClose={() => setAlert({} as any)} />
                <form id="sign-up-form" onSubmit={onSubmit} className="space-y-6" action="#" method="POST">
                    <InputWithLabel label="Full name" id="fullName" data-testid="fullName" name="fullName" type="text" autoComplete="fullName" required />
                    <InputWithLabel label="Email" id="email" data-testid="email" name="email" type="email" autoComplete="email" required />
                    <InputWithLabel label="Phone Number" id="phoneNumber" data-testid="phoneNumber" name="phoneNumber" type="tel" autoComplete="phoneNumber" required />
                    <InputWithLabel label="Password" id="password" data-testid="password" name="password" type="password" autoComplete="current-password" required />
                    <div>
                        <button type="submit" data-testid="sign-up" className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Sign up</button>
                    </div>
                </form>
                <div className=' justify-center flex mt-3'>
                    Existing User <Link className='ml-1 text-blue-500' to='/login'>Sign In</Link>
                </div>
            </div>
        </div>
    )
}

export default Registration