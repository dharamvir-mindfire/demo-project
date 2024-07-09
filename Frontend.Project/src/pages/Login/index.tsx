import React, { useState } from 'react'
import { useLoginMutation } from '../../services/authServices';
import { Link } from 'react-router-dom';
import Alert from '../../base-components/Alert';
import InputWithLabel from '../../base-components/InputWithLabel';
import { setAuthUser } from './Redux'
import { connect } from 'react-redux';

const Login = ({ setAuthUser }: { setAuthUser: (payload: any) => void }) => {
    const [loginUser] = useLoginMutation();
    const [alert, setAlert] = useState({ title: "", message: '' })
    const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        var formData = new FormData(event.currentTarget)
        const payload: any = {
            userName: formData.get("userName"),
            password: formData.get("password"),
        }
        loginUser(payload).then((res) => {

            (setAuthUser(res?.data))
            if (!res.error) {
                setAlert({
                    title: 'Success',
                    message: 'LoggedIn Successfully'
                })
            } else {
                setAlert({
                    title: 'Failed',
                    message: "Failed to login"
                })
            }
        }).catch(() => { })
    }
    return (
        <div className="flex min-h-full flex-col justify-center px-6 py-8 lg:px-8">
            <div className="sm:mx-auto sm:w-full sm:max-w-sm">
                <img className="mx-auto h-10 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600" alt="Your Company" />
                <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">User Login</h2>
            </div>
            <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
                <Alert visible={Boolean(alert?.message)} {...alert} onRequestClose={() => setAlert({} as any)} />
                <form id="sign-in-form" onSubmit={onSubmit} className="space-y-6" action="#" method="POST">
                    <InputWithLabel label="User Name" id="userName" data-testid="userName" name="userName" type="text" autoComplete="fullName" required />
                    <InputWithLabel label="Password" id="password" data-testid="password" name="password" type="password" autoComplete="current-password" required />
                    <div>
                        <button type="submit" data-testid="sign-in" className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Sign in</button>
                    </div>
                </form>
                <div className=' justify-center flex mt-3'>
                    New User <Link className='ml-1 text-blue-500' to='/register'>Sign Up</Link>
                </div>
            </div>
        </div>
    )
}
const mapStateToProps = ({ }) => ({})
const mapDispatchToProps = (dispatch: any) => ({ setAuthUser: (payload: any) => dispatch(setAuthUser(payload)) })
export default connect(mapStateToProps, mapDispatchToProps)(Login)