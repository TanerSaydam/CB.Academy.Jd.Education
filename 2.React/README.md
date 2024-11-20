# React Eğitim İçeriği ve Ders Programı

## 19.11.2024
- [x] proxy
- [x] State Management
	- [x] Context API
		- [x] [ContextName].Provider
		- [x] React Hooks
			- [x] createContext
			- [x] useContext	
	- [x] Zustand
		- [x] create
		- [x] devtool

## 18.11.2024
- [x] SPA Nedir?
- [x] React nedir?
- [x] React kurulumu ve projeyi çalıştırma
- [x] Component nedir?
- [x] Class component
- [x] Function component
- [x] JSX Nedir?
- [x] Virtual DOM
- [x] Değişken oluşturma
- [x] React Hooks
	- [x] useState
- [x] Function ve Arrow Function
- [x] Style
- [x]  (Pratik Zamanı) Personel projesi yapalım
- [x] Router (React Router eski)
	- [ ] Link
		- [ ] state
		- [ ] Hooks
			- [ ] useLocation
	- [x] NavLink
		- [x] isActive
		- [x] isPending
	- [ ] Hooks
		- [ ] useNavigate
		- [ ] useParams
- [x] Router (React Router yeni)
	- [x] RouterProvider
	- [x] Data Router
		- [x] createBrowserRouter
- [x] API istekleri
- [x] Fetch
- [x] Axios
- [x] Data Router
	- [x] createBrowserRouter
- [x] Life Cycle ve Life Cycle Methods
- [x] React Hooks
	- [x] useEffect

## State Management
- [x] State Management
	- [ ] Redux Toolkit
		- [ ] Provider
		- [ ] createSlice
		- [ ] configureStore
		- [ ] createAsyncThunk
		- [ ] createApi
		- [ ] Hooks			
			- [ ] useSelector

## Libraries
- [ ] React Tanstack Query (Axios, Fetch)
- [ ] React Formik

## Hooks
- [ ] React Hooks
	- [ ] useMemo
	- [ ] useRef
 	- [ ] useCallback
 	- [ ] useLayoutEffect
 	- [ ] useImperativeHandle
 	- [ ] useTransition (React 18 ve sonrası)
 	- [ ] useDeferredValue (React 18 ve sonrası)
 	- [ ] useId (React 18 ve sonrası)
 	- [ ] useSyncExternalStore (React 18 ve sonrası)
 	- [ ] useInsertionEffect (React 18 ve sonrası)

- [ ] Zod - React Hook Form
```jsx
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";

const schema = z.object({
  name: z.string().min(1, "Ad gerekli."),
  age: z.number().min(18, "Yaş en az 18 olmalı."),
});

type FormData = z.infer<typeof schema>;

function App() {
  const { register, handleSubmit, formState: { errors } } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  const onSubmit = (data: FormData) => {
    console.log(data);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register("name")} />
      {errors.name && <p>{errors.name.message}</p>}
      <input type="number" {...register("age")} />
      {errors.age && <p>{errors.age.message}</p>}
      <button type="submit">Gönder</button>
    </form>
  );
}
```
- [ ] ion18
- [ ] Prisma ORM + MongoDb + NextAPI Root Full Stack Proje

## Dökümantasyonlar:
- React Documentation için <a href="https://tr.react.dev/" target="_blank">buraya tıklayın</a>
- React Router için <a href="https://reactrouter.com/en/main" target="_blank">buraya tıklayın</a>
- React Zustand için <a href="https://zustand-demo.pmnd.rs/" target="_blank">buraya tıklayın</a>
- React Redux için <a href="https://react-redux.js.org/" target="_blank">buraya tıklayın</a>
- React Tanstack Query için <a href="https://tanstack.com/query/latest" target="_blank">buraya tıklayın</a>
- React Formik için <a href="https://formik.org/" target="_blank">buraya tıklayın</a>
- React Hook Form için <a href="https://react-hook-form.com/" target="_blank">buraya tıklayın</a>

## Kurulumlar
Node.JS kurulumu için <a href="https://nodejs.org/en" target="_blank">buraya tıklayın</a>

CLI komutları için Powershell güvenlik iznini değiştirme
```powershel
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

React projesi oluşturma
```powershell
npx create-react-app my-app
```

Vite js ile React projesi oluşturma
```powershell
npm create vite@latest my-react-app -- --template react-ts
```

Zustand
```powershell
npm install zustand
```

Redux
```powershell
npm install @reduxjs/toolkit react-redux
```

Tanstack
```powershell
npm i @tanstack/react-query
```

Formik
```powershell
npm install formik
# For validation
npm install yup
```

React Hook Form
```powershell
npm install react-hook-form
# For validation
npm install zod
npm install @hookform/resolvers
```

proxy
```powershell
npm install http-proxy-middleware --save
```

src folder altında <b>setupProxy.js</b> adıyla dosya kaydedilmeli
```js
const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function(app) {
  app.use(
    '/todos',
    createProxyMiddleware({
      target: 'https://jsonplaceholder.typicode.com',
      changeOrigin: true,
    })
  );
};
```