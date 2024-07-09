import React from 'react'
import { persist, store } from './'
import { Provider, useDispatch, useSelector } from 'react-redux'
import { PersistGate } from 'redux-persist/integration/react'

export const ReduxProvider = ({ children }: any) => {
  return (
    <Provider store={store}>
      <PersistGate persistor={persist} loading={null}>
        {children}
      </PersistGate>
    </Provider>
  )
}
export type RootState = ReturnType<typeof store.getState>
export const useAppSelector = useSelector.withTypes<RootState>()
type AppDispatch = typeof store.dispatch
export const useAppDispatch = useDispatch.withTypes<AppDispatch>()