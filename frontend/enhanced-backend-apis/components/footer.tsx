'use client'

import { Github } from 'lucide-react'
import { motion } from 'framer-motion'

export function Footer() {
  return (
    <motion.footer 
      className="bg-background/80 backdrop-blur-sm border-t"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.5 }}
    >
      <div className="container mx-auto px-4 py-6 flex flex-col md:flex-row justify-between items-center">
        <p className="text-sm text-muted-foreground mb-4 md:mb-0">&copy; 2023 Enhanced Backend APIs. All rights reserved.</p>
        <motion.a
          href="https://github.com/yourusername/enhanced-backend-apis"
          target="_blank"
          rel="noopener noreferrer"
          className="flex items-center space-x-2 text-primary hover:text-primary/80 transition-colors"
          whileHover={{ scale: 1.05 }}
          whileTap={{ scale: 0.95 }}
        >
          <Github size={20} />
          <span>View on GitHub</span>
        </motion.a>
      </div>
    </motion.footer>
  )
}

