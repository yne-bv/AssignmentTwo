import {useEffect, useState} from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {CartesianGrid, Legend, Line, LineChart, Tooltip, XAxis, YAxis} from "recharts";

function App() {
    const [data, setData] = useState<any>(null);
    useEffect(() => {
        fetch(`http://localhost:7062/WeatherForecast`)
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
                throw response;
            }).then(data => {
                setData(data)
        });
    }, []);
    
  return (
    <> 
        <h1>Værdata</h1>
        <LineChart
            width={500}
            height={300}
            data={data}
            margin={{
                top: 5,
                right: 30,
                left: 20,
                bottom: 5,
            }}
        >
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="city" />
            <YAxis />
            <Tooltip />
            <Legend />
            <Line type="monotone" dataKey="temperatureC" stroke="#8884d8" activeDot={{ r: 8 }} />
        </LineChart>
        <LineChart
            width={500}
            height={300}
            data={data}
            margin={{
                top: 5,
                right: 30,
                left: 20,
                bottom: 5,
            }}
        >
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="city" />
            <YAxis />
            <Tooltip />
            <Legend />
            <Line type="monotone" dataKey="windKph" stroke="#8884d8" activeDot={{ r: 8 }} />
        </LineChart>
    </>
  )
}

export default App
