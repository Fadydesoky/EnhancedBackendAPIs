'use client'

import { useState } from 'react'
import { useTheme } from 'next-themes'
import { Moon, Sun, Menu, X } from 'lucide-react'
import Link from 'next/link'
import { motion, AnimatePresence } from 'framer-motion'

const Header = () => {
  const { theme, setTheme } = useTheme()
  const [isMenuOpen, setIsMenuOpen] = useState(false)

  const menuItems = [
    { href: "/", label: "Home" },
    { href: "/rest", label: "REST API" },
    { href: "/soap", label: "SOAP API" },
    { href: "/grpc", label: "gRPC API" },
  ]

  return (
    <motion.header 
      className="bg-background/80 backdrop-blur-sm shadow-md"
      initial={{ opacity: 0, y: -20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.5 }}
    >
      <nav className="container mx-auto px-4 py-4 flex justify-between items-center">
        <Link href="/" className="text-2xl font-bold bg-clip-text text-transparent bg-gradient-to-r from-primary to-secondary">
          Enhanced Backend APIs
        </Link>
        <div className="flex items-center space-x-4">
          <motion.button
            whileHover={{ scale: 1.1 }}
            whileTap={{ scale: 0.9 }}
            onClick={() => setTheme(theme === 'dark' ? 'light' : 'dark')}
            className="p-2 rounded-full hover:bg-primary/20"
          >
            {theme === 'dark' ? <Sun size={24} /> : <Moon size={24} />}
          </motion.button>
          <div className="relative md:hidden">
            <motion.button
              whileHover={{ scale: 1.1 }}
              whileTap={{ scale: 0.9 }}
              onClick={() => setIsMenuOpen(!isMenuOpen)}
              className="flex items-center space-x-2 text-primary hover:text-primary/80"
            >
              {isMenuOpen ? <X size={24} /> : <Menu size={24} />}
            </motion.button>
          </div>
          <div className="hidden md:flex space-x-4">
            {menuItems.map((item) => (
              <Link 
                key={item.href} 
                href={item.href} 
                className="text-primary hover:text-primary/80 transition-colors"
              >
                {item.label}
              </Link>
            ))}
          </div>
        </div>
      </nav>
      <AnimatePresence>
        {isMenuOpen && (
          <motion.div 
            initial={{ opacity: 0, height: 0 }}
            animate={{ opacity: 1, height: 'auto' }}
            exit={{ opacity: 0, height: 0 }}
            className="md:hidden bg-background/90 backdrop-blur-sm"
          >
            {menuItems.map((item) => (
              <Link 
                key={item.href} 
                href={item.href} 
                className="block px-4 py-2 text-primary hover:bg-primary/20 hover:text-primary-foreground transition-colors"
                onClick={() => setIsMenuOpen(false)}
              >
                {item.label}
              </Link>
            ))}
          </motion.div>
        )}
      </AnimatePresence>
    </motion.header>
  )
}

export default Header

