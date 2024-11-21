import ReactDOM from 'react-dom/client';
import App, { MyCountReducer } from './App';
import { Provider } from 'react-redux';
import { store } from './features/store';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

const queryClient = new QueryClient();

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <QueryClientProvider client={queryClient}>
    <Provider store={store}>
      <MyCountReducer/>
    </Provider>
  </QueryClientProvider>
);