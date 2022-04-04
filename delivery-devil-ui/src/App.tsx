import { QueryClientProvider, QueryClient } from 'react-query';
import './App.css';
import AppRouter from './AppRouter';

const client = new QueryClient()

function App() {
  return (
    <QueryClientProvider client={client}>
      <div className="App">
          <AppRouter />
      </div>
    </QueryClientProvider>
  );
}

export default App;
