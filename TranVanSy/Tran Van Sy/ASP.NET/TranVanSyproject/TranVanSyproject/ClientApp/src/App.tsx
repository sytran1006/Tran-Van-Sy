import React from 'react';
import { BrowserRouter } from 'react-router-dom';

function App() {
    return (
        <BrowserRouter>
        <div className="App">
            <header className="App-header">
                <p>
                    Edit <code>src/App.tsx</code> and save to reload.
                </p>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>
            </header>
            </div>
        </BrowserRouter>
    );
}

export default App;
