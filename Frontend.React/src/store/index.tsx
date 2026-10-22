import { combineReducers, configureStore } from '@reduxjs/toolkit'
// Or from '@reduxjs/toolkit/query/react'
import { setupListeners } from '@reduxjs/toolkit/query'
import { authServices } from '../services/authServices'
import { rootReducers } from './reducers'
import storage from 'redux-persist/lib/storage'
import persistReducer from 'redux-persist/es/persistReducer'
import persistStore from 'redux-persist/es/persistStore'
import { empServices } from '../services/empServices'

const persistConfig = {
  key: 'demo-root',
  storage,
  blacklist: [authServices.reducerPath, empServices.reducerPath],

}
const persistedReducer = persistReducer(persistConfig, rootReducers)

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [
          'persist/PERSIST',
          'persist/REHYDRATE',
          'persist/PAUSE',
          'persist/PURGE',
          'persist/FLUSH',
          'persist/REGISTER',
        ],
      },
    }).concat(authServices.middleware, empServices.middleware),
})
export const persist = persistStore(store)
setupListeners(store.dispatch)

export * from './ReduxProvider'