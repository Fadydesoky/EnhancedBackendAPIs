'use client'

import Link from 'next/link'
import { motion } from 'framer-motion'

const cardVariants = {
  hidden: { opacity: 0, y: 20 },
  visible: { opacity: 1, y: 0 },
}

export default function Home() {
  return (
    <div className="flex flex-col items-center justify-center min-h-[calc(100vh-4rem)] py-2">
      <motion.section 
        className="mb-12 text-center"
        initial={{ opacity: 0, y: -20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <h2 className="text-4xl font-bold mb-4 bg-clip-text text-transparent bg-gradient-to-r from-primary to-secondary">
          Explore Different API Types
        </h2>
        <p className="max-w-2xl mx-auto text-lg">
          This application demonstrates the integration of various API types including REST, SOAP, and gRPC.
          Each API connects to the same SQLite database, allowing you to compare and contrast their implementations.
        </p>
      </motion.section>
      <motion.h1 
        className="text-5xl font-bold mb-8 bg-clip-text text-transparent bg-gradient-to-r from-primary to-secondary"
        initial={{ opacity: 0, scale: 0.5 }}
        animate={{ opacity: 1, scale: 1 }}
        transition={{ duration: 0.5 }}
      >
        Welcome to Enhanced Backend APIs
      </motion.h1>
      <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
        {[
          { href: "/rest", title: "REST API", description: "Explore users data using REST API" },
          { href: "/soap", title: "SOAP API", description: "Explore users data using SOAP API" },
          { href: "/grpc", title: "gRPC API", description: "Explore users data using gRPC API" },
        ].map((item, index) => (
          <motion.div
            key={item.href}
            variants={cardVariants}
            initial="hidden"
            animate="visible"
            transition={{ duration: 0.5, delay: index * 0.1 }}
          >
            <Link href={item.href} className="block p-6 bg-card hover:bg-card/90 text-card-foreground rounded-lg shadow-lg hover:shadow-xl transition-all duration-300 transform hover:-translate-y-1">
              <h2 className="text-2xl font-bold mb-2">{item.title}</h2>
              <p>{item.description}</p>
            </Link>
          </motion.div>
        ))}
      </div>
    </div>
  )
}

