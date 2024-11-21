import Script from "next/script";
import "./globals.css";
import { Header } from "@/components/header";

export default function RootLayout({ children }) {
  return (
    <html lang="en">      
      <body className="container">
        <Header/>
        {children}  
        <Script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" />     
      </body>
    </html>
  );
}