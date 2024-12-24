"use client";

import './globals.css'
import { Inter } from 'next/font/google'
import { ThemeProvider } from '@/components/theme-provider'
import { Toaster } from 'react-hot-toast'
import Header from '@/components/header'
import { QueryClientProvider } from '@tanstack/react-query'
import { queryClient } from '@/lib/react-query'
import { Footer } from '@/components/footer'
import BackgroundScene from '@/components/background-scene'
import { motion } from 'framer-motion'

const inter = Inter({ subsets: ['latin'] })

export const metadata = {
  title: 'Enhanced Backend APIs',
  description: 'Frontend for REST, SOAP, and gRPC APIs',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en" suppressHydrationWarning>
      <body className={`${inter.className} gradient-bg`}>
        <ThemeProvider attribute="class" defaultTheme="system" enableSystem>
          <QueryClientProvider client={queryClient}>
            <BackgroundScene />
            <div className="relative z-10 min-h-screen flex flex-col bg-background/80 backdrop-blur-sm text-foreground">
              <Header />
              <motion.main 
                className="container mx-auto px-4 py-8 flex-grow"
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.5 }}
              >
                {children}
              </motion.main>
              <Footer />
            </div>
            <Toaster />
          </QueryClientProvider>
        </ThemeProvider>
      </body>
    </html>
  )
}
